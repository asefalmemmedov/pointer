using Pointer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Pointer.Utilities.Utilities;
using Pointer.Extensions;

namespace Pointer.Areas.Admin.Controllers
{
    [AdminAuthenticate]
    public class DashboardController : Controller
    {
        private readonly PointerContext context;
        public DashboardController()
        {
            context = new PointerContext();
        }
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var item = context.AdminSetting.FirstOrDefault();
          
            return View();
        }
    }
}