namespace Pointer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "FulName", c => c.String(maxLength: 50));
            DropColumn("dbo.Blog", "SupTitle");
            DropColumn("dbo.Blog", "Description");
            DropColumn("dbo.Blog", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blog", "DateTime", c => c.String(maxLength: 50));
            AddColumn("dbo.Blog", "Description", c => c.String(maxLength: 500));
            AddColumn("dbo.Blog", "SupTitle", c => c.String(maxLength: 100));
            DropColumn("dbo.Blog", "FulName");
        }
    }
}
