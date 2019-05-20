namespace Pointer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastaded : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contact", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "Title", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
