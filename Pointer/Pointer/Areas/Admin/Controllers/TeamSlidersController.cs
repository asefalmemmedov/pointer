using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Pointer.DAL;
using Pointer.Models;
using static Pointer.Extensions.FileExtensions;
using static Pointer.Utilities.Utilities;
namespace Pointer.Areas.Admin.Controllers
{
    [AdminAuthenticate]
    public class TeamSlidersController : Controller
    {
        private PointerContext db = new PointerContext();

       
        public ActionResult Index()
        {
            return View(db.TeamSliders.ToList());
        }

       
   

        
        public ActionResult Create()
        {
          
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>  Create([Bind(Include = "Id,Photo")] TeamSlider teamSlider)
        {
            if (!ModelState.IsValid)
            {
                return View(teamSlider);               
            }
            if (teamSlider.Photo == null)
            {
                ModelState.AddModelError("", "Photo can't be null");
                return View(teamSlider);

            }
            if (!teamSlider.Photo.IsImage())
            {
                ModelState.AddModelError("", "Photo type is not valid");
                return View(teamSlider);
            }
            teamSlider.Image = teamSlider.Photo.Save("img");

            db.TeamSliders.Add(teamSlider);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
            //}

            //return View(teamSlider);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamSlider teamSlider = db.TeamSliders.Find(id);
            if (teamSlider == null)
            {
                return HttpNotFound();
            }
            return View(teamSlider);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>  Edit([Bind(Include = "Id,Photo")] TeamSlider teamSlider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamSlider).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(teamSlider);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamSlider teamSlider = db.TeamSliders.Find(id);
            if (teamSlider == null)
            {
                return HttpNotFound();
            }
            return View(teamSlider);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamSlider teamSlider = db.TeamSliders.Find(id);
            db.TeamSliders.Remove(teamSlider);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
