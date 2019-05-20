using Pointer.DAL;
using Pointer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Pointer.Utilities.Utilities;
using Pointer.Extensions;
namespace Pointer.Areas.Admin.Controllers
{
    [AdminAuthenticate]
    public class ServicesController : Controller
    {
        private readonly PointerContext context;
        public ServicesController()
        {
            context = new PointerContext();
        }
        // GET: Admin/Services
        public ActionResult Index()
        {
            return View(context.Services.ToList());
        }

        public ActionResult Create()
        {

            if (context.Services.Count()==12)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Title,Content")]Services services)
        {
            context.Services.Add(services);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {

            var model = await context.Services.FirstOrDefaultAsync(x => x.id == id);
           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Services services)
        {
            Services newservices =await context.Services.FirstOrDefaultAsync(x => x.id == services.id);
            newservices.Title = services.Title;
            newservices.Content = services.Content;
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Delete(int? id)
        {
            var model = await context.Services.FirstOrDefaultAsync(d => d.id == id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Services services)
        {
            Services deletservices = await context.Services.FirstOrDefaultAsync(c => c.id == services.id);
            context.Services.Remove(deletservices);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}