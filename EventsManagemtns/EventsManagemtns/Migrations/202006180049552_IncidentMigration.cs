namespace EventsManagemtns.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncidentMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        Urgancey = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Sverity = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incidents", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Incidents", new[] { "OrganizationId" });
            DropTable("dbo.Incidents");
        }
    }
}
