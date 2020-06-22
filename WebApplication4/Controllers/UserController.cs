using DBModel_DAL;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication4.App_Start;
using WebServices;

namespace WebApplication4.Controllers
{
    [AuthorizeCustom("Admin")]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(HttpContext.Request.Cookies[".ASPXAUTH"].Value);
            ViewBag.Role = JsonConvert.DeserializeObject<UserModel>(ticket.UserData).Role.ToString();
            return View();
        }
        public ActionResult GetUser()
        {
            IUserService userService = new UserService();
            var result = userService.GetUsers();
            return PartialView("_UserTable", result);
        }
    }
}