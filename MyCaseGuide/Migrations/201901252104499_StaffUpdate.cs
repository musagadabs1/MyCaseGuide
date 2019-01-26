namespace MyCaseGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StaffUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Staffs", "UserType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "UserType", c => c.String(nullable: false));
            DropColumn("dbo.Staffs", "Type");
        }
    }
}
