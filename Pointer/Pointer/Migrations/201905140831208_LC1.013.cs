namespace Pointer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LC1013 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.About", "BigText", c => c.String(maxLength: 300));
            AddColumn("dbo.About", "NormalText", c => c.String(maxLength: 300));
            AddColumn("dbo.About", "SmallText", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.About", "SmallText");
            DropColumn("dbo.About", "NormalText");
            DropColumn("dbo.About", "BigText");
        }
    }
}
