namespace MyCaseGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Invoice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        MyCaseId = c.Int(nullable: false),
                        FeeStructure = c.Single(nullable: false),
                        TotalAmountDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnpaidBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.MyCases", t => t.MyCaseId, cascadeDelete: true)
                .Index(t => t.MyCaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "MyCaseId", "dbo.MyCases");
            DropIndex("dbo.Invoices", new[] { "MyCaseId" });
            DropTable("dbo.Invoices");
        }
    }
}
