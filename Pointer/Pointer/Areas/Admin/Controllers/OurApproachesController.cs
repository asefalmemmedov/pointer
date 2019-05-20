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
using static Pointer.Utilities.Utilities;
using Pointer.Extensions;
namespace Pointer.Areas.Admin.Controllers
{
    public class OurApproachesController : Controller
    {
        private PointerContext db = new PointerContext();

      
        public ActionResult Index()
        {
            return View(db.OurApproach.ToList());
        }

      
    
      
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>  Create([Bind(Include = "Id,Title,Content")] OurApproach ourApproach)
        {
            if (ModelState.IsValid)
            {
                db.OurApproach.Add(ourApproach);
              await  db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ourApproach);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurApproach ourApproach = db.OurApproach.Find(id);
            if (ourApproach == null)
            {
                return HttpNotFound();
            }
            return View(ourApproach);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content")] OurApproach ourApproach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ourApproach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ourApproach);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurApproach ourApproach = db.OurApproach.Find(id);
            if (ourApproach == null)
            {
                return HttpNotFound();
            }
            return View(ourApproach);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>  DeleteConfirmed(int id)
        {
            OurApproach ourApproach = db.OurApproach.Find(id);
            db.OurApproach.Remove(ourApproach);
           await db.SaveChangesAsync();
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
