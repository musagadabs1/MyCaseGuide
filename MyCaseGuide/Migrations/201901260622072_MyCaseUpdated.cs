namespace MyCaseGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyCaseUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MyCases", "PracticeArea", c => c.String(nullable: false));
            AlterColumn("dbo.MyCases", "CaseStage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MyCases", "CaseStage", c => c.Int(nullable: false));
            AlterColumn("dbo.MyCases", "PracticeArea", c => c.Int(nullable: false));
        }
    }
}
