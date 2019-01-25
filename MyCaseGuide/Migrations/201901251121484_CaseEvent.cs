namespace MyCaseGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CaseEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaseEvents",
                c => new
                    {
                        CaseEventId = c.Int(nullable: false, identity: true),
                        MyCaseId = c.Int(nullable: false),
                        StaffID = c.Int(nullable: false),
                        DateAndTime = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        EventName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CaseEventId)
                .ForeignKey("dbo.MyCases", t => t.MyCaseId, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: true)
                .Index(t => t.MyCaseId)
                .Index(t => t.StaffID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CaseEvents", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.CaseEvents", "MyCaseId", "dbo.MyCases");
            DropIndex("dbo.CaseEvents", new[] { "StaffID" });
            DropIndex("dbo.CaseEvents", new[] { "MyCaseId" });
            DropTable("dbo.CaseEvents");
        }
    }
}
