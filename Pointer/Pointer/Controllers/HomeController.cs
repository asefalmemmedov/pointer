using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Pointer.Areas.Admin.Controllers;
using Pointer.DAL;
using Pointer.Models;
using Pointer.Models.ViewModels;

namespace Pointer.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly PointerContext context;

        public HomeController()
        {
            context = new PointerContext();
        }

        public async Task<ActionResult> Index()
        {
            HomeIndexVM vm = new HomeIndexVM
            {
                Header = await context.Headers.FirstOrDefaultAsync(),
                About = await context.About.FirstOrDefaultAsync(),
                Teams = await context.Teams.OrderByDescending(x => x.Id).Skip(0).Take(8).ToListAsync(),
                TeamSliders = await context.TeamSliders.OrderBy(c => c.Id).Skip(0).Take(4).ToListAsync(),
                Services = await context.Services.OrderBy(c => c.id).Skip(0).Take(20).ToListAsync(),
                Contact = context.Contacts.FirstOrDefault(),
                Testimonials = await context.Testimonials.OrderBy(t => t.id).Skip(0).Take(6).ToListAsync(),
                Blog=await context.Blogs.OrderBy(b=>b.id).Skip(0).Take(3).ToListAsync(),
                OurApproach=await context.OurApproach.OrderBy(o=>o.Id).Skip(0).Take(3).ToListAsync()

            };

            return View(vm);
        }
   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ContactInfo(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index",contact);
            }
           

            context.Contacts.Add(contact);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}