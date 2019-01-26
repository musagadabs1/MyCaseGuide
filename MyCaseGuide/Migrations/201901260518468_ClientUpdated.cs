namespace MyCaseGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "ContactGroup", c => c.String(nullable: false));
            AlterColumn("dbo.Staffs", "Type", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Staffs", "Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "ContactGroup", c => c.Int(nullable: false));
        }
    }
}
