namespace Pointer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PointerLC1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SupTitle = c.String(maxLength: 100),
                        Title = c.String(maxLength: 100),
                        Content = c.String(maxLength: 500),
                        Image = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Headers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Profection = c.String(nullable: false, maxLength: 300),
                        Image = c.String(maxLength: 300),
                        Facebook = c.String(maxLength: 100),
                        Linkedn = c.String(maxLength: 100),
                        Twitter = c.String(maxLength: 100),
                        Instagram = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamSlider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeamSlider");
            DropTable("dbo.Team");
            DropTable("dbo.Headers");
            DropTable("dbo.About");
        }
    }
}
