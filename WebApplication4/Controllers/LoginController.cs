using DBModel_DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication4.App_Start;
using WebServices;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ModalLogin()
        {
            return View();
        }

        public ActionResult Ident(LoginModel loginModel)
        {
            // Je verifie si le model est valid
            if (ModelState.IsValid)
            {
                //// je rempli l'objet de ma DAL
                UserModel userModel = new UserModel();
                userModel.Email = loginModel.LoginEmail;
                userModel.Password = loginModel.LoginPassword;
                //userModel.Role = DBModel.Roles.Client;
                // J'instancie le service
                IUserService userService = new UserService();

                if (userService.UserExist(userModel))
                {
                    //userModel.IsConnected = true;

                    // je vais chercher en db les infos de cet utilisateur

                    var userInfos = userService.GetUser(userModel);
                    userModel.Role = userInfos.Role;
                    // Je crée un coockie d'authent du nom .ASPXAUTH
                    //System.Web.Security.FormsAuthentication.SetAuthCookie(loginModel.LoginEmail, true);

                    var objectJson = JsonConvert.SerializeObject(userModel);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Constantes.Authent, DateTime.Now,
                                                            DateTime.Now.AddMinutes(30),
                                                            true, objectJson, FormsAuthentication.FormsCookiePath);

                    Response.Cookies.Add
                                            (
                                                new HttpCookie
                                                (
                                                    FormsAuthentication.FormsCookieName,
                                                    FormsAuthentication.Encrypt(ticket)
                                                )
                                            );

                    return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }
            else
                return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

    }
}
