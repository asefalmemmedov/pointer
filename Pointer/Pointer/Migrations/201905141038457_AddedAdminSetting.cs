namespace Pointer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAdminSetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminSetting",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminSetting");
        }
    }
}
