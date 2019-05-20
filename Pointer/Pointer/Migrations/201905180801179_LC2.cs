namespace Pointer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LC2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdminSetting", "Image", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdminSetting", "Image");
        }
    }
}
