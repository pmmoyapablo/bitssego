using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sisgtfhka.Models;
using Sisgtfhka.Services;
using static Sisgtfhka.Enums.Enums;

namespace Sisgtfhka.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly SignInManager<ApplicationUser> _signInManager;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly ClientHttpREST _clientHttpREST;
        protected readonly ILogger _logger;

        protected const string SessionKeyRol = "RolId";
        protected const string SessionKeyAccess = "LevelAccess";
        protected const string SessionDistributorId = "DistributorId";
        protected const string SessionTechnicalId = "TechnicalId";

        public BaseController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ClientHttpREST clientHttpREST,
            IOptions<AppSettings> settings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _clientHttpREST = clientHttpREST;
            AppSettings appSettings = settings.Value;
        }

        public BaseController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ClientHttpREST clientHttpREST,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings)
        { 
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _clientHttpREST = clientHttpREST;
            _logger = logger;
            AppSettings appSettings = settings.Value;
        }

        public async override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //Compruebo Acceso del Rol a Recursos por si hay Intento Forzado por URL
            string path = filterContext.HttpContext.Request.Path.Value;
            
            if (!path.Contains("/Account/") && !path.Contains("/Manage/"))
            {
                bool check = await this.IsRouteAceessToRol(filterContext.Controller.ToString());

                if (!check)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Account",
                        action = "AccessDenied"
                    }));
                }
            }
    
        }

        public void Alert(string message, NotificationType notificationType)
        {  
            var msg = "<script language='javascript'>swal('" + Enums.Enums.GetEnumDescription(notificationType).ToUpper() + "', '" + message + "','" + notificationType + "')" + "</script>";
            TempData["notification"] = msg;
        }
        /// <summary>
        /// Sets the information for the system notification.
        /// </summary>
        /// <param name="message">The message to display to the user.</param>
        /// <param name="notifyType">The type of notification to display to the user: Success, Error or Warning.</param>
        public void Message(string message, NotificationType notifyType)
        {
            TempData["Notification2"] = message;

            switch (notifyType)
            {
                case NotificationType.success:
                    TempData["NotificationCSS"] = "alert-box success";
                    break;
                case NotificationType.error:
                    TempData["NotificationCSS"] = "alert-box errors";
                    break;
                case NotificationType.warning:
                    TempData["NotificationCSS"] = "alert-box warning";
                    break;

                case NotificationType.info:
                    TempData["NotificationCSS"] = "alert-box notice";
                    break;
            }
        }

        public void ClearSessionVars()
        {
            SessionExtensions.SetInt32(HttpContext.Session, SessionKeyRol, 0);
            SessionExtensions.SetInt32(HttpContext.Session, SessionKeyAccess, 0);
            SessionExtensions.SetInt32(HttpContext.Session, SessionDistributorId, 0);
            SessionExtensions.SetInt32(HttpContext.Session, SessionTechnicalId, 0);
        }

        private async Task<bool> IsRouteAceessToRol(string pPathRoute)
        {
            bool pin = false;

            var userIdentity = await _userManager.GetUserAsync(User);

            if (userIdentity != null)
            {
                var claims = await _userManager.GetClaimsAsync(userIdentity);
                if (claims.Count > 0)
                {
                    var claim = claims.FirstOrDefault();
                    string repJson = claim.Value;

                    List<MenuModel> listMenus = TypeModel<MenuModel>.DeserializeInArray(repJson);
                    string[] arrayStr = pPathRoute.Split('.');
                    string nameController = arrayStr[2].Replace("Controller", "");
                    MenuModel menu = listMenus.Where(e => e.url.Contains(nameController) && e.visible == true ).FirstOrDefault();

                    if(menu != null)
                    {                      
                       pin = true;
                    }
                }
                else
                { pin = true; }
            }
            else
            { pin = true; }

            return pin;
        }

        #region Token Access

        protected async Task<string> GetTokenAccess()
        {
            var userIdentity = await _userManager.GetUserAsync(User);

            if (userIdentity == null)
            {  //Ya hubo un Logout en otra instancia, entones reinicio la Sesión
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");

                RedirectToAction(nameof(AccountController.Login), "Account");

                return "";

            }

            string tokenValue = "Bearer " + await _userManager.GetAuthenticationTokenAsync(userIdentity, "Bearer", "Token JWT");

            return tokenValue;
        }

        #endregion

        #region ID Profiles y Access [Properties OnlyRead]

        protected int? RolId
        {
            get
            {
                var value = SessionExtensions.GetInt32(HttpContext.Session, SessionKeyRol);

                return value;
            }
        }

        protected int? LevelAccess
        {
            get
            {
                var value = SessionExtensions.GetInt32(HttpContext.Session, SessionKeyAccess);

                return value;
            }
        }

        protected int? DistributorId
        {
            get
            {
                var value = SessionExtensions.GetInt32(HttpContext.Session, SessionDistributorId);

                return value;
            }
        }

        protected int? TechnicalId
        {
            get
            {
                var value = SessionExtensions.GetInt32(HttpContext.Session, SessionTechnicalId);

                return value;
            }
        }

        #endregion
    }
}
