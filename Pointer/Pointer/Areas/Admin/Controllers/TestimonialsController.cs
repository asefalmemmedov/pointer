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
    public class TestimonialsController : Controller
    {
        private PointerContext db = new PointerContext();

      
        public ActionResult Index()
        {
            return View(db.Testimonials.ToList());
        }

   

       //Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Content,FullName,Image")] Testimonials testimonials)
        {
            if (ModelState.IsValid)
            {
                db.Testimonials.Add(testimonials);
              await  db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(testimonials);
        }

        //Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonials testimonials = db.Testimonials.Find(id);
            if (testimonials == null)
            {
                return HttpNotFound();
            }
            return View(testimonials);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit([Bind(Include = "id,Content,FullName,Image")] Testimonials testimonials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testimonials).State = EntityState.Modified;
               await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testimonials);
        }

       //Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonials testimonials = db.Testimonials.Find(id);
            if (testimonials == null)
            {
                return HttpNotFound();
            }
            return View(testimonials);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Testimonials testimonials = db.Testimonials.Find(id);
            db.Testimonials.Remove(testimonials);
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
