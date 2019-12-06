namespace OData.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialScaffolding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectDetails",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        TechnologiesUsed = c.String(),
                        ManagerName = c.String(),
                        Description = c.String(),
                        TeamSize = c.Int(nullable: false),
                        PlannedBudget = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProjectNumber = c.String(nullable: false),
                        ProjectName = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectDetails", "Id", "dbo.Projects");
            DropIndex("dbo.ProjectDetails", new[] { "Id" });
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectDetails");
        }
    }
}
