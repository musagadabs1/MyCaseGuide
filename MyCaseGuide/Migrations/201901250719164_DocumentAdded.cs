namespace MyCaseGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        MyCaseId = c.Int(nullable: false),
                        DocName = c.String(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        Tags = c.String(),
                        Description = c.String(),
                        CreatedBy = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.MyCases", t => t.MyCaseId, cascadeDelete: true)
                .Index(t => t.MyCaseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "MyCaseId", "dbo.MyCases");
            DropIndex("dbo.Documents", new[] { "MyCaseId" });
            DropTable("dbo.Documents");
        }
    }
}
