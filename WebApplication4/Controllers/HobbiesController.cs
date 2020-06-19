using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HobbiesController : Controller
    {
        
        // GET: Hobbies
        public ActionResult Index()
        {
            return View();
        }

        // GET: Hobbies/Details/5
        public ActionResult Details(int? id)
        {
            
            return View();
        }

        // GET: Hobbies/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Hobbies/Edit/5
        public ActionResult Edit(int? id)
        {
            
            return View();
        }
    }
}
