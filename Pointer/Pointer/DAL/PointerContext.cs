using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Pointer.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Pointer.DAL
{
    public class PointerContext : DbContext
    {
        public PointerContext() : base("PointerContext")
        {
        }

        public DbSet<Headers> Headers { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSlider> TeamSliders { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet <Blog> Blogs { get; set; }
        public DbSet <TestimonialsSlider>  TestimonialsSliders{ get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AdminSetting> AdminSetting { get; set; }
        public DbSet<OurApproach> OurApproach { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        
    }
}