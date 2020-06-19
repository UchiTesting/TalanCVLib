using DBModel_DAL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication4.App_Start;
using WebApplication4.ViewModel;
using WebServices;

namespace WebApplication4.Controllers
{
    [AuthorizeCustom("Admin", "Consultant", "Recruiter")]
    public class ProfilesController : Controller
    {
         private readonly IProfileService _profileService;
         public ProfilesController()
            {
                _profileService = new ProfileService();
            }

         public ActionResult Details()
            {
                var result = _profileService.GetProfile();
                return PartialView("_ProfileTable", result);
            }

        public ActionResult Index()
        {
            var result = _profileService.GetProfiles();
            return PartialView("_ProfileTable", result);
        }
        



    }
}
