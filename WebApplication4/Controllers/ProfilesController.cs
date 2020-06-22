using DBModel_DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
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

        
        public ActionResult Index()
        {
            var result = _profileService.GetProfiles();
            
            return View("Index", result);
        }
        
        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ProfileModel profile = _profileService.GetProfileByID(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfileID,FisrtName,LastName,Gender,Adress,BirthOfDate")] ProfileModel profile)
        {
            if (ModelState.IsValid)
            {
                _profileService.PostProfile(profile);
                
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        //GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileModel profile = _profileService.GetProfileByID(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        //POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfileModel profile = _profileService.GetProfileByID(id);
            _profileService.PostDeleteProfile(profile);
            return RedirectToAction("Index");
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfileModel profile = _profileService.GetProfileByID(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfileID,FisrtName,LastName,Gender,Adress,BirthOfDate")] ProfileModel profile)
        {
            if (ModelState.IsValid)
            {
                _profileService.PostEditProfile(profile);
                
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        //    // GET: Profiles/Delete/5
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Profile profile = db.Profiles.Find(id);
        //        if (profile == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(profile);
        //    }

        //    // POST: Profiles/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        Profile profile = db.Profiles.Find(id);
        //        db.Profiles.Remove(profile);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //} return View();
        //    }



    }
}
