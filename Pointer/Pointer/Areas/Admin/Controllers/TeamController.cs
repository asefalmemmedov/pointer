using System.Web.Mvc;
using Pointer.Models;
using Pointer.DAL;
using Pointer.Extensions;
using System.Threading.Tasks;
using static Pointer.Utilities.Utilities;
using static Pointer.Extensions.FileExtensions;
namespace Pointer.Areas.Admin.Controllers
{
    [AdminAuthenticate]
    public class TeamController : Controller
    {
       
        private readonly PointerContext context;
        public TeamController()
        {
            context = new PointerContext();
        }
        // GET: Admin/Team
        public ActionResult Index()
        {
            return View(context.Teams);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>  Create([Bind(Include = "Name,LastName,Photo,Facebook,Profection,Linkedn,Twitter,Instagram")]Team team)
        {
           if (!ModelState.IsValid) return View(team);

            if (team.Photo==null)
            {
                ModelState.AddModelError("Photo", "Foto yuklenmelidir.");
                return View(team);
            }

            if (!team.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Foto duzgun formatda deyil.");
                return View(team);
            }

            team.Image = team.Photo.Save("img");
            context.Teams.Add(team);
           await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}