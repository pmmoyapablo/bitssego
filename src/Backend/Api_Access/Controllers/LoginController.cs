using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Access.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Api_Access.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AccessContext _context;

        public LoginController(AccessContext context)
        {
            _context = context;
        }

        // POST: api/Login
        /// <summary>
        /// Autentica a un usuario para Obtener un Token de Acceso
        /// </summary>
        /// <param name="user">Usuario</param>
        /// <param name="signingConfigurations"></param>
        /// <param name="tokenConfigurations"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public object LoginUser([FromBody] User user, 
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool credenciaisValidas = false;

            if (user != null && !String.IsNullOrWhiteSpace(user.username))
            {
                //Verifico si el usuario existe
                if (this.UserExists(user.username))
                {
                    // Efetua o login en base a las credenciales del usuario almacenadas
                    string encpass = EncrypterPassword(user.password);
                    var resultadoLogin = _context.Sisg_Users.Where(u => u.username == user.username).FirstOrDefault(); //&& u.password == encpass

                    if (resultadoLogin != null)
                    {
                        user = resultadoLogin;
                        credenciaisValidas = true;
                    }
                }
            }

            if (credenciaisValidas)
            {
                if (user.enable == 0)
                {  //Usuario inactivo
                    return new
                    {
                        authenticated = false,
                        message = "Usuario inactivo"
                    };
                }

                ClaimsIdentity identity = new ClaimsIdentity(
                   new GenericIdentity(user.username, "Login"),
                   new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.username)
                   }
               );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                   TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler(); 
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                user.rol = _context.Sisg_Roles.Where(r => r.id == user.rolId).FirstOrDefault();
                user.rol.profile = _context.Sisg_Profiles.Where(p => p.id == user.rol.profileId).FirstOrDefault();
                user.rol.access = _context.Sisg_Accessroles.Where(a => a.id == user.rol.accessId).FirstOrDefault();

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK",
                    userData = user
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Error al autenticar"
                };
            }

        }

        // GET: api/Login/username
        [AllowAnonymous]
        [HttpGet("{pUsername}")]
        public IActionResult GetUserAnonymous([FromRoute] String pUsername)
        {
            if (this.UserExists(pUsername))
            {
                return Ok(pUsername);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{pUsername}")]
        public async Task<IActionResult> PutUserAnonymous([FromRoute] String pUsername, [FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (pUsername == null || pUsername == "")
                {
                    return BadRequest();
                }

                var userStore = _context.Sisg_Users.Where(u => u.username == pUsername).FirstOrDefault();

                if (userStore == null)
                {
                    return BadRequest();
                }

                userStore.password = user.password;

                user = userStore;

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
                return NotFound(ex.Message);
            }
        }

        private bool UserExists(string username)
        {
            var user = _context.Sisg_Users.Where(u => u.username == username).FirstOrDefault();

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
    }
}