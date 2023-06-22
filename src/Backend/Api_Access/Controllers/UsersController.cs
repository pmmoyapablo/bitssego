using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Access.Models;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Api_Access.Services;
using Microsoft.Extensions.Options;

namespace Api_Access.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AccessContext _context;
        private readonly IEmailSender _emailSender;
        private readonly IOptions<AppSettings> _settings;

        public UsersController(AccessContext context, 
            IEmailSender emailSender,
            IOptions<AppSettings> settings)
        {
            _context = context;
            _emailSender = emailSender;
            _settings = settings;
        }

        #region // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetSisg_Users()
        {
            try
            {
                foreach (User us in _context.Sisg_Users.ToList())
                {
                    us.rol = _context.Sisg_Roles.Where(r => r.id == us.rolId).FirstOrDefault();
                    us.rol.profile = _context.Sisg_Profiles.Where(p => p.id == us.rol.profileId).FirstOrDefault();
                    us.rol.access = _context.Sisg_Accessroles.Where(a => a.id == us.rol.accessId).FirstOrDefault();
                }

                return _context.Sisg_Users;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var us = await _context.Sisg_Users.FindAsync(id);

                if (us == null)
                {
                    return NotFound();
                }
                else
                {
                    us.rol = _context.Sisg_Roles.Where(r => r.id == us.rolId).FirstOrDefault();
                    us.rol.profile = _context.Sisg_Profiles.Where(p => p.id == us.rol.profileId).FirstOrDefault();
                    us.rol.access = _context.Sisg_Accessroles.Where(a => a.id == us.rol.accessId).FirstOrDefault();
                }

                return Ok(us);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != user.id)
                {
                    return BadRequest();
                }

                if (user.password.Length < 28)
                 {
                    user.password = EncrypterPassword(user.password);
                 }               

                _context.Entry(user).State = EntityState.Modified;

                user.creation_date = DateTime.Now;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return NotFound(ex.Message);
                }
            }
        }
        #endregion
     
        #region // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            try
            {               
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string passwordGenerate = this.GenerarPassword(8);
                user.password = passwordGenerate;
               
                user.password = EncrypterPassword(user.password);
                user.creation_date = DateTime.Now;

                _context.Sisg_Users.Add(user);              
                await _context.SaveChangesAsync();
              
                user.rol = _context.Sisg_Roles.Where(r => r.id == user.rolId).FirstOrDefault();

                this.SenMailNotification(user, passwordGenerate);

                return CreatedAtAction("GetUser", new { id = user.id }, user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var User = await _context.Sisg_Users.FindAsync(id);

                if (User == null)
                {
                    return NotFound();
                }

                _context.Sisg_Users.Remove(User);
                await _context.SaveChangesAsync();

                return Ok(User);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        private bool UserExists(int id)
        {           
            var user = _context.Sisg_Users.Where(e => e.id == id).FirstOrDefault();

            if (user != null)
            { return true; }
            else
            { return false; }
        }

        private string EncrypterPassword(string pOriginPassword)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(pOriginPassword);
            byte[] hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }

        private async void SenMailNotification(User user, string passwordGenerate)
        {
            try
            {
                _emailSender.LoadConfigurations(_settings.Value);

                string message = @"Bienvenido a la plataforma de Gestión SGOTFHKA.
                                   Ha sido registrado con el rol de: <b>" + user.rol.description + @"</b><br>
                                   Sus datos de acceso son los siguientes: <br>
                                   <p><b>Usuario:</b> " + user.username + @"</p>
                                   <p><b>Clave:</b> " + passwordGenerate + @"</p><br>
                                   A partir de ahora puedes ingresar en esta enlace: <a href='" + _settings.Value.URL_Site + "'>SGOTFHKA</a>";

                await _emailSender.SendEmailAsync(user.username, "Registro Nuevo Usuario", message);

            }
            catch (Exception)
            {
            }

        }
        private string GenerarPassword(int longitud)
        {
            string password = string.Empty;
            string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            Random EleccionAleatoria = new Random();

            for (int i = 0; i < longitud; i++)
            {
                int LetraAleatoria = EleccionAleatoria.Next(0, 100);
                int NumeroAleatorio = EleccionAleatoria.Next(0, 9);

                if (LetraAleatoria < letras.Length)
                {
                    password += letras[LetraAleatoria];
                }
                else
                {
                    password += NumeroAleatorio.ToString();
                }
            }

            if (!password.Any(c => char.IsUpper(c)))
                {
                  string letterUppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                  char letter = letterUppers[EleccionAleatoria.Next(0, letterUppers.Length - 1)];
                  password += letter.ToString();
                }

            return password;
        }
    }
}