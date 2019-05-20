using System;
using System.Web;
using System.IO;

namespace Pointer.Extensions
{
    public static class FileExtensions
    {
        public static bool IsImage(this HttpPostedFileBase file)
        {
            return file.ContentType == "image/jpg" ||
                   file.ContentType == "image/jpeg" ||
                   file.ContentType == "image/png" ||
                   file.ContentType == "image/gif";
        }

        public static string Save(this HttpPostedFileBase image, string subfolder)
        {
            string newFilename = subfolder + "/" + Guid.NewGuid().ToString() + Path.GetFileName(image.FileName);

            string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Public"), newFilename);

            image.SaveAs(fullPath);

            return newFilename;
        }

        public static string SaveAsAdministrator(this HttpPostedFileBase image, string subfolder)
        {
            string newFilename = Guid.NewGuid().ToString() + Path.GetFileName(image.FileName);

            string fullPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Areas/Admin/Public/images"), subfolder, newFilename);

            image.SaveAs(fullPath);

            return newFilename;
        }
    }
}


////namespace Pointer.Migrations
////{
////    using System;
////    using System.Data.Entity;
////    using System.Data.Entity.Migrations;
////    using System.Linq;

////    internal sealed class Configuration : DbMigrationsConfiguration<Pointer.DAL.PointerContext>
////    {
////        public Configuration()
////        {
////            AutomaticMigrationsEnabled = false;
////        }

////        protected override void Seed(Pointer.DAL.PointerContext context)
////        {
////            //  This method will be called after migrating to the latest version.

////            //  You can use the DbSet<T>
////            //.AddOrUpdate() helper extension method
////            //  to avoid creating duplicate seed data.
////            context.Teams.AddOrUpdate(x => new { x.Id, x.Name, x.Profection, x.Image },
////            new Models.Team
////            {
////                Id = 1,
////                Name = "Aslan",
////                LastName = "Aslanov",
////                Image = "person_6.jpg",
////                Profection = "Usta Malyar",
////                Facebook = "http://localhost:50045/Home/Index",
////                Linkedn = "http://localhost:50045/Home/Index",
////                Instagram = "http://localhost:50045/Home/Index",
////                Twitter = "http://localhost:50045/Home/Index"
////            },

////            new Models.Team
////            {
////                Id = 2,
////                Name = "Aslan",
////                LastName = "Aslanov",
////                Image = "person_6.jpg",
////                Profection = "Usta Malyar",
////                Facebook = "http://localhost:50045/Home/Index",
////                Linkedn = "http://localhost:50045/Home/Index",
////                Instagram = "http://localhost:50045/Home/Index",
////                Twitter = "http://localhost:50045/Home/Index"
////            }, new Models.Team
////            {
////                Id = 3,
////                Name = "celil",
////                LastName = "ceil",
////                Image = "person_6.jpg",
////                Profection = "Usta Malyar",
////                Facebook = "http://localhost:50045/Home/Index",
////                Linkedn = "http://localhost:50045/Home/Index",
////                Instagram = "http://localhost:50045/Home/Index",
////                Twitter = "http://localhost:50045/Home/Index"

////            },
////            new Models.Team
////            {
////                Id = 4,
////                Name = "Aslan",
////                LastName = "Aslanov",
////                Image = "person_6.jpg",
////                Profection = "Usta Malyar",
////                Facebook = "http://localhost:50045/Home/Index",
////                Linkedn = "http://localhost:50045/Home/Index",
////                Instagram = "http://localhost:50045/Home/Index",
////                Twitter = "http://localhost:50045/Home/Index"
////            },

////            new Models.Team
////            {
////                Id = 5,
////                Name = "Aslan",
////                LastName = "Aslanov",
////                Image = "person_6.jpg",
////                Profection = "Usta Malyar",
////                Facebook = "http://localhost:50045/Home/Index",
////                Linkedn = "http://localhost:50045/Home/Index",
////                Instagram = "http://localhost:50045/Home/Index",
////                Twitter = "http://localhost:50045/Home/Index"
////            },

////            new Models.Team
////            {
////                Id = 6,
////                Name = "Aslan",
////                LastName = "Aslanov",
////                Image = "person_6.jpg",
////                Profection = "Usta Malyar",
////                Facebook = "http://localhost:50045/Home/Index",
////                Linkedn = "http://localhost:50045/Home/Index",
////                Instagram = "http://localhost:50045/Home/Index",
////                Twitter = "http://localhost:50045/Home/Index"
////            },

////            new Models.Team
////            {
////                Id = 7,
////                Name = "Aslan",
////                LastName = "Aslanov",
////                Image = "person_6.jpg",
////                Profection = "Usta Malyar",
////                Facebook = "http://localhost:50045/Home/Index",
////                Linkedn = "http://localhost:50045/Home/Index",
////                Instagram = "http://localhost:50045/Home/Index",
////                Twitter = "http://localhost:50045/Home/Index"
////            }
////            );
////        }
////    }
////}
