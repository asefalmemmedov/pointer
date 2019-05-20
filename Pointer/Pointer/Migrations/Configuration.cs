namespace Pointer.Migrations
{
    using Pointer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Helpers;
    internal sealed class Configuration : DbMigrationsConfiguration<Pointer.DAL.PointerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pointer.DAL.PointerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.AdminSetting.AddOrUpdate(a => a.Email,
                new AdminSetting { Email="asaf@gmail.com",Password=Crypto.HashPassword("asef123456"),Image="Admin/avatar-01.jpg" });

        }
    }
}
