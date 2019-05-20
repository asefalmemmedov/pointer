namespace Pointer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Databsaeupdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contact", "Address");
            DropColumn("dbo.Contact", "Phone");
            DropColumn("dbo.Contact", "EmailAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "EmailAddress", c => c.String(maxLength: 100));
            AddColumn("dbo.Contact", "Phone", c => c.String(maxLength: 100));
            AddColumn("dbo.Contact", "Address", c => c.String(maxLength: 100));
        }
    }
}
