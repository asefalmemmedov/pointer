using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Pointer.DAL;
using Pointer.Models;
using static Pointer.Utilities.Utilities;
using Pointer.Extensions;
using System.Data.Entity;
using System.IO;

namespace Pointer.Areas.Admin.Controllers
{
    [AdminAuthenticate]
    public class HeaderController : Controller
    {
        private readonly PointerContext context;
        public HeaderController()
        {
            context = new PointerContext();
        }
        public ActionResult Index()
        {

            return View(context.Headers.FirstOrDefault());
        }

        public ActionResult Edit() => View(context.Headers.FirstOrDefault());

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit(Headers headers, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid) return View(headers);

            Headers headerFromDb = context.Headers.FirstOrDefault();
            string imagename;
            if (file == null)
            {
                imagename = headerFromDb.Image;
            }
            headerFromDb.Title = headers.Title;
            headerFromDb.Description = headers.Description;
            await context.SaveChangesAsync();

            if (file != null && file.ContentLength > 0)
            {
                imagename = file.FileName;

                string exe = file.ContentType.ToLower();
                if (exe != "image/jpg" &&
                     exe != "image/png" &&
                     exe != "image/jpeg" &&
                     exe != "image/gif")
                {
                    return View(headers);
                }
                int id = headerFromDb.id;
                Headers dto = await context.Headers.OrderBy(c => c.id).Skip(0).Take(20).FirstOrDefaultAsync(x => x.id == id);
                dto.Image = imagename;
                await context.SaveChangesAsync();
                var orginalDirectory = new DirectoryInfo(string.Format("{0}Public\\img", Server.MapPath(@"\")));
                var pathstring = Path.Combine(orginalDirectory.ToString(), imagename);
                file.SaveAs(pathstring);
            }

            return RedirectToAction("Index");
        }


      
    }


}