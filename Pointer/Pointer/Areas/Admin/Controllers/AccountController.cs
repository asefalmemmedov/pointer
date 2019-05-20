using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Pointer.Areas.Admin.Models;
using Pointer.DAL;
using static Pointer.Utilities.Utilities;
using Pointer.Extensions;
namespace Pointer.Areas.Admin.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly PointerContext context;
        public AccountController()
        {
            context = new PointerContext();
        }
        // GET: Admin/Acount
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include ="Email,Password")]LoginModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);
            var admin = context.AdminSetting.FirstOrDefault(a => a.Email == loginModel.Email);
            if (admin==null)
            {
                ModelState.AddModelError("", "Email or Password is invalid");
                return View(loginModel);
            }

            if (!Crypto.VerifyHashedPassword(admin.Password,loginModel.Password))
            {
                ModelState.AddModelError("", "Email or Password is invalid");
                return View(loginModel); 
            }
            Session["admin"] = admin;
            return RedirectToAction("Index","Dashboard");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}