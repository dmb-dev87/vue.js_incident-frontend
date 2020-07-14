namespace EventsManagemtns.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrganizationMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SectorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sectors", t => t.SectorID, cascadeDelete: true)
                .Index(t => t.SectorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "SectorID", "dbo.Sectors");
            DropIndex("dbo.Organizations", new[] { "SectorID" });
            DropTable("dbo.Organizations");
        }
    }
}
