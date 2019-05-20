using Pointer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Pointer.Utilities.Utilities;
using Pointer.Extensions;
using System.Threading.Tasks;

namespace Pointer.Areas.Admin.Controllers
{
    [AdminAuthenticate]
    public class SettingsController : Controller
    {
        private readonly PointerContext context;
        public SettingsController()
        {
            context=new PointerContext();
        }
        // GET: Admin/Settings
        public ActionResult ChangeAvatar()
        {
            var model = context.AdminSetting.FirstOrDefault();
            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<ActionResult>  ChangeAvatar(HttpPostedFileBase image)
        {
            if (image !=null)
            {
                if (image.IsImage())
                {

                    var adminSetting = context.AdminSetting.FirstOrDefault();

                    //Remove
                    RemoveImageAsAdministrator(adminSetting.Image);

                    //Save
                    adminSetting.Image = image.SaveAsAdministrator("Admin");
                   await context.SaveChangesAsync();
                    return RedirectToAction("Index", "Dashboard");

                }
                ViewBag.UploadError = "Image type is not invalid";
            }

            ViewBag.Image = context.AdminSetting.FirstOrDefault().Image;
            ViewBag.UploadError = "Image should be selected";
            return View();
        }
    }
}