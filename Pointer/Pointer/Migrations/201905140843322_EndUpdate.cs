namespace Pointer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EndUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SupTitle = c.String(maxLength: 100),
                        Title = c.String(maxLength: 100),
                        Content = c.String(maxLength: 300),
                        Description = c.String(maxLength: 500),
                        DateTime = c.String(maxLength: 50),
                        Image = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Subject = c.String(maxLength: 300),
                        Message = c.String(nullable: false, maxLength: 500),
                        Address = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 100),
                        EmailAddress = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 500),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Image = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TestimonialsSlider",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.id);
            
            DropColumn("dbo.About", "BigText");
            DropColumn("dbo.About", "NormalText");
            DropColumn("dbo.About", "SmallText");
        }
        
        public override void Down()
        {
            AddColumn("dbo.About", "SmallText", c => c.String(maxLength: 300));
            AddColumn("dbo.About", "NormalText", c => c.String(maxLength: 300));
            AddColumn("dbo.About", "BigText", c => c.String(maxLength: 300));
            DropTable("dbo.TestimonialsSlider");
            DropTable("dbo.Testimonials");
            DropTable("dbo.Services");
            DropTable("dbo.Contact");
            DropTable("dbo.Blog");
        }
    }
}
