using DBModel_DAL;
using System.Web.Mvc;
using WebApplication4.App_Start;
using WebServices;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [AuthorizeCustom("Admin")]
    public class DashboardController : Controller
    {
        private readonly IUserService _userService;
        private UserModel _userModel;
        public DashboardController()
        {
            _userService = new UserService();
        }
       
        // GET: Dashboard
        public ActionResult Index()
        {
            var result = _userService.GetUser();
            ViewBag.Title = result.Nom;
            ViewBag.UserName = result.Nom;
            return View();
        }

        public ActionResult Welcome(int numTimes = 1)
        {
            ViewBag.Message = "Hello " + _userModel.Nom;
            ViewBag.NumTimes = numTimes;
            return View();
        }




        public ActionResult Ident(LoginModel loginModel)
        {
            
            if (ModelState.IsValid)
                {
                    UserModel userModel = new UserModel();
                    userModel.Email = loginModel.LoginEmail;
                    userModel.Password = loginModel.LoginPassword;
                    

                if (_userService.UserExist(userModel))
                {
                    
                    _userModel = userModel;
                    return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else { return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; }

                }
            else { return new JsonResult { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; }


        }
    }
}
                