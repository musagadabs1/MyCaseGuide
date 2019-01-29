namespace MyCaseGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventCaseChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CaseEvents", "Start", c => c.DateTime(nullable: false));
            AddColumn("dbo.CaseEvents", "End", c => c.DateTime(nullable: false));
            DropColumn("dbo.CaseEvents", "DateAndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CaseEvents", "DateAndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.CaseEvents", "End");
            DropColumn("dbo.CaseEvents", "Start");
        }
    }
}
