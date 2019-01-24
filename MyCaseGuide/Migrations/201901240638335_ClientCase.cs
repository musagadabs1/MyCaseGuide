namespace MyCaseGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientCase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyCases",
                c => new
                    {
                        MyCaseId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        StaffId = c.Int(nullable: false),
                        CaseName = c.String(nullable: false),
                        CaseNumber = c.Int(nullable: false),
                        Opened = c.DateTime(nullable: false),
                        PracticeArea = c.Int(nullable: false),
                        CaseStage = c.Int(nullable: false),
                        Description = c.String(),
                        StatuteOfLimitation = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MyCaseId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        UserType = c.String(nullable: false),
                        BillingRate = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateTable(
                "dbo.StaffMyCases",
                c => new
                    {
                        Staff_StaffId = c.Int(nullable: false),
                        MyCase_MyCaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Staff_StaffId, t.MyCase_MyCaseId })
                .ForeignKey("dbo.Staffs", t => t.Staff_StaffId, cascadeDelete: true)
                .ForeignKey("dbo.MyCases", t => t.MyCase_MyCaseId, cascadeDelete: true)
                .Index(t => t.Staff_StaffId)
                .Index(t => t.MyCase_MyCaseId);
            
            AlterColumn("dbo.Clients", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffMyCases", "MyCase_MyCaseId", "dbo.MyCases");
            DropForeignKey("dbo.StaffMyCases", "Staff_StaffId", "dbo.Staffs");
            DropForeignKey("dbo.MyCases", "ClientId", "dbo.Clients");
            DropIndex("dbo.StaffMyCases", new[] { "MyCase_MyCaseId" });
            DropIndex("dbo.StaffMyCases", new[] { "Staff_StaffId" });
            DropIndex("dbo.MyCases", new[] { "ClientId" });
            AlterColumn("dbo.Clients", "Address", c => c.String());
            AlterColumn("dbo.Clients", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Clients", "EmailAddress", c => c.String());
            AlterColumn("dbo.Clients", "LastName", c => c.String());
            AlterColumn("dbo.Clients", "FirstName", c => c.String());
            DropTable("dbo.StaffMyCases");
            DropTable("dbo.Staffs");
            DropTable("dbo.MyCases");
        }
    }
}
