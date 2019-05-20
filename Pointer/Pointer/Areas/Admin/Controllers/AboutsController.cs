using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    [AdminAuthenticate]
    public class AboutsController : Controller
    {
        private PointerContext db = new PointerContext();

      
        public async Task< ActionResult >Index()
        {
            var model = await db.About.Take(50).ToListAsync();
            return View(model);
        }

       
        public async Task< ActionResult >Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About about =await db.About.FindAsync(id);
            if (about == null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,SupTitle,Title,Content")] About about, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid) return View();
            var modelabout = await db.About.Take(20).FirstOrDefaultAsync(x => x.id == about.id);
            modelabout.Content = about.Content;
            modelabout.Title = about.Title; 
            modelabout.SupTitle = about.SupTitle;
            await db.SaveChangesAsync();
            string imagename;
            int id = modelabout.id;
            var model = await db.About.Take(20).FirstOrDefaultAsync(c => c.id == id);
            if (file == null)
            {
                imagename = modelabout.Image;
                model.Image = imagename;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            if (file != null && file.ContentLength > 0)
            {
                imagename = file.FileName;
                model.Image = imagename;
                await db.SaveChangesAsync();
                var orginalDirectory = new DirectoryInfo(string.Format("{0}Public\\img", Server.MapPath(@"\")));
                var pathstring = Path.Combine(orginalDirectory.ToString(), imagename);
                file.SaveAs(pathstring);

            }
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
