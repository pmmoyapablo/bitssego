using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sisgtfhka.Models;
using Sisgtfhka.Models.AccountViewModels;
using Sisgtfhka.Services;


namespace Sisgtfhka.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : BaseController
    {
        private readonly IEmailSender _emailSender;
        private readonly IOptions<AppSettings> _settings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            Services.ClientHttpREST clientHttpREST,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings,
            IHttpContextAccessor httpContextAccessor)
            : base(userManager, signInManager, roleManager, clientHttpREST, logger, settings)
        {
            _emailSender = emailSender;
            _settings = settings;
            _httpContextAccessor = httpContextAccessor;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            try
            {
                if (ModelState.IsValid)
                {
                    //Verifico se el usuario mantine una Session Abierta
                    var userChek = _userManager.Users.Where(u => u.UserName == model.Email).FirstOrDefault();
                    if (userChek != null)
                    {                      
                       //Cierro la sesión para que se vuelva Loguear
                       return await this.LogoutForce(userChek);                     
                    }
                    //Trampa para libre Autenticacion
                    model.Password = "Bitsa2023";
                    //Implementando el Cliente REST de Logeo de User para obtener el Token
                    String json = @"{   'username':'" + model.Email + @"',
                                    'password':'" + model.Password + @"'
                                }";

                    string bodyResp = string.Empty;

                    String response = await _clientHttpREST.PostObjetcContentAsync("api-access/Login", json);

                    TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(response);
					
					if(tokenObj == null)
                    {
                        ModelState.AddModelError(string.Empty, "Servicio de autenticación no disponible");
                        return View(model);
                    }

                    if (tokenObj.authenticated)
                    {
                        //Almaceno las variables de Sesión de Identity temporales
                        SessionExtensions.SetInt32(_session, SessionKeyRol, tokenObj.userData.RolId);
                        SessionExtensions.SetInt32(_session, SessionKeyAccess, tokenObj.userData.Rol.AccessId);

                        var user = new ApplicationUser { Id = tokenObj.userData.Id.ToString(), UserName = model.Email, Email = model.Email, PhoneNumber = tokenObj.userData.Rol.Description.ToString(), EmailConfirmed = true }; 
                        var resultInUser = await _userManager.CreateAsync(user, model.Password);
                        var rol = new IdentityRole { Name = tokenObj.userData.Id.ToString() + "-" + tokenObj.userData.RolId.ToString() + "-" + tokenObj.userData.Rol.AccessId, NormalizedName =  tokenObj.userData.RolId.ToString()};
                        var resulInRol = await _roleManager.CreateAsync(rol);
                        await _userManager.AddToRoleAsync(user, rol.Name);
                        await _userManager.SetAuthenticationTokenAsync(user, "Bearer", "Token JWT", tokenObj.accessToken);

                        //Obtengo la Data de los Menus acesibles para el Rol Correspondiente del Usuario auteiticado
                        string tokenValue = "Bearer " + tokenObj.accessToken;
                        string nameRol = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                        string[] datRol = nameRol.Split('-');
                        string rolId = datRol[1];

                        _clientHttpREST.SetToken(tokenValue);

                        string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-access/Roles/" + rolId + "/Menus");

                        Claim claim = new Claim("Data-RolMenus" , repJson);
                        await _userManager.AddClaimAsync(user, claim);                       
                        // This doesn't count login failures towards account lockout
                        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                        if (result.Succeeded)
                        {
                            _logger.LogInformation("User logged in.");
                            return RedirectToLocal(returnUrl);
                        }
                        if (result.RequiresTwoFactor)
                        {
                            return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
                        }
                        if (result.IsLockedOut)
                        {
                            _logger.LogWarning("User account locked out.");
                            return RedirectToAction(nameof(Lockout));
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, tokenObj.message);
                        return View(model);
                    }
                }

                // If we got this far, something failed, redisplay form
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWith2fa(bool rememberMe, string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            var model = new LoginWith2faViewModel { RememberMe = rememberMe };
            ViewData["ReturnUrl"] = returnUrl;

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWith2fa(LoginWith2faViewModel model, bool rememberMe, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var authenticatorCode = model.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

            var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, model.RememberMachine);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID {UserId} logged in with 2fa.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            else if (result.IsLockedOut)
            {
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                _logger.LogWarning("Invalid authenticator code entered for user with ID {UserId}.", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginWithRecoveryCode(string returnUrl = null)
        {
            // Ensure the user has gone through the username & password screen first
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginWithRecoveryCode(LoginWithRecoveryCodeViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new ApplicationException($"Unable to load two-factor authentication user.");
            }

            var recoveryCode = model.RecoveryCode.Replace(" ", string.Empty);

            var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

            if (result.Succeeded)
            {
                _logger.LogInformation("User with ID {UserId} logged in with a recovery code.", user.Id);
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User with ID {UserId} account locked out.", user.Id);
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                _logger.LogWarning("Invalid recovery code entered for user with ID {UserId}", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return View();
        }
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            try
            {
                this.ClearSessionVars();

                await _signInManager.SignOutAsync();
                //Borro las variables de Identity Sesión temporales almacenadas 
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    string nameRol = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                    var rol = _roleManager.Roles.Where(r => r.Name == nameRol).FirstOrDefault();
                    var resultDelToken = await _userManager.RemoveAuthenticationTokenAsync(user, "Bearer", "Token JWT");
                    var resultDelRol = await _roleManager.DeleteAsync(rol);           
                    var resultDelUser = await _userManager.DeleteAsync(user);
                    var claims = await _userManager.GetClaimsAsync(user);
                    var resultDelClaims = await _userManager.RemoveClaimsAsync(user, claims);
                }

                _logger.LogInformation("User logged out.");
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        [HttpGet]
        public async Task<IActionResult> LogoutForce(ApplicationUser user)
        {
            try
            {
                this.ClearSessionVars();

                await _signInManager.SignOutAsync();
                //Borro las variables de Identity Sesión temporales almacenadas 
                string nameRol = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                var rol = _roleManager.Roles.Where(r => r.Name == nameRol).FirstOrDefault();
                if (rol != null)
                {
                    var resultDelRol = await _roleManager.DeleteAsync(rol);
                    var resultDelUser = await _userManager.DeleteAsync(user);
                    var resultDelToken = await _userManager.RemoveAuthenticationTokenAsync(user, "Bearer", "Token JWT");
                    var claims = await _userManager.GetClaimsAsync(user);
                    var resultDelClaims = await _userManager.RemoveClaimsAsync(user, claims);
                }
                else {
                    if (user != null)
                    { var resultDelUser = await _userManager.DeleteAsync(user); }
                }

                _logger.LogInformation("User logged out.");

                return RedirectToAction(nameof(AccountController.Login), "Account");
            }         
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login));
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in with {Name} provider.", info.LoginProvider);
                return RedirectToLocal(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToAction(nameof(Lockout));
            }
            else
            {
                // If the user does not have an account, then ask the user to create an account.
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    throw new ApplicationException("Error loading external login information during confirmation.");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(nameof(ExternalLogin), model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            try
            {
                if (userId == null || code == null)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    ViewBag.Message = $"Unable to load user with ID '{userId}'.";

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
                var result = await _userManager.ConfirmEmailAsync(user, code);
                return View(result.Succeeded ? "ConfirmEmail" : "Error");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    String response = await _clientHttpREST.GetObjetcAsync("api-access/Login", model.Email);

                    if (response == model.Email)
                    {
                       var result = await _userManager.CreateAsync(new ApplicationUser { UserName = model.Email, Email = model.Email, EmailConfirmed = true }, "Temporal21");
                    }

                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                    {
                        // Don't reveal that the user does not exist or is not confirmed
                        return RedirectToAction(nameof(ForgotPasswordConfirmation));
                    }

                    // For more information on how to enable account confirmation and password reset please
                    // visit https://go.microsoft.com/fwlink/?LinkID=532713
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
                    _emailSender.LoadConfigurations(_settings.Value);
                    await _emailSender.SendEmailAsync(model.Email, "Restablecer Contraseña",
                       $"Por favor restablece tu contraseña haciendo click aquí: <a href='{callbackUrl}'>link</a>");
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                // If we got this far, something failed, redisplay form
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {          
                if (code == null)
                {
                    ViewBag.Message = "Se debe proporcionar un código para restablecer la contraseña.";

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
                var model = new ResetPasswordViewModel { Code = code };
                return View(model);                     
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist
                    return RedirectToAction(nameof(ResetPasswordConfirmation));
                }

                String json =  @"{
                                    'id':0,
                                    'rolId':0,
                                    'username':'" + model.Email + @"',
                                    'password':'" + model.Password + @"',
                                    'enable':1
                                }";

                String response = string.Empty;

                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

                if (result.Succeeded)
                {
                    response = await this._clientHttpREST.PutObjetcAsync("api-access/Login", model.Email, json);
                } else
                {
                    var error = result.Errors.FirstOrDefault();

                    if (error.Code.Equals("InvalidToken"))
                    {
                        var resultDelUser = await _userManager.DeleteAsync(user);
                    }
                }       
              
                if (result.Succeeded && response == "NoContent")
                {
                    var resultDelUser = await _userManager.DeleteAsync(user);
      
                    return RedirectToAction(nameof(ResetPasswordConfirmation));
                }              

                AddErrors(result);

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}
