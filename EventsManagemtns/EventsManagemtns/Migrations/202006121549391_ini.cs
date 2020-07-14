namespace EventsManagemtns.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.APTs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Counter = c.Int(nullable: false),
                        DbSuccess = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AlternativeNames",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Serial = c.Int(nullable: false),
                        Name = c.String(),
                        dbStatus = c.String(),
                        Status_Id = c.Int(),
                        APT_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .ForeignKey("dbo.APTs", t => t.APT_id)
                .Index(t => t.Status_Id)
                .Index(t => t.APT_id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusString = c.String(),
                        StatusType_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StatusTypes", t => t.StatusType_id)
                .Index(t => t.StatusType_id);
            
            CreateTable(
                "dbo.AttachmentProps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Extension = c.String(),
                        Filename = c.String(),
                        Type = c.String(),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentString = c.String(),
                        DbStatus = c.String(),
                        CreatedBy = c.String(),
                        createdDate = c.DateTime(nullable: false),
                        APT_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.APTs", t => t.APT_id)
                .Index(t => t.APT_id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        Contenant = c.String(),
                        dbStatus = c.String(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.ThreatSignatures",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Serial = c.Int(nullable: false),
                        Name = c.String(),
                        DomainName = c.String(),
                        dbStatus = c.String(),
                        APT_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.APTs", t => t.APT_id)
                .Index(t => t.APT_id);
            
            CreateTable(
                "dbo.StatusTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        statusType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AptAttachments",
                c => new
                    {
                        APT_id = c.Int(nullable: false),
                        AttachmentProp_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.APT_id, t.AttachmentProp_Id })
                .ForeignKey("dbo.APTs", t => t.APT_id, cascadeDelete: true)
                .ForeignKey("dbo.AttachmentProps", t => t.AttachmentProp_Id, cascadeDelete: true)
                .Index(t => t.APT_id)
                .Index(t => t.AttachmentProp_Id);
            
            CreateTable(
                "dbo.OriginCountries",
                c => new
                    {
                        Country_Id = c.Int(nullable: false),
                        APT_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country_Id, t.APT_id })
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .ForeignKey("dbo.APTs", t => t.APT_id, cascadeDelete: true)
                .Index(t => t.Country_Id)
                .Index(t => t.APT_id);
            
            CreateTable(
                "dbo.TargetedCountries",
                c => new
                    {
                        Country_Id = c.Int(nullable: false),
                        APT_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country_Id, t.APT_id })
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .ForeignKey("dbo.APTs", t => t.APT_id, cascadeDelete: true)
                .Index(t => t.Country_Id)
                .Index(t => t.APT_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Status", "StatusType_id", "dbo.StatusTypes");
            DropForeignKey("dbo.ThreatSignatures", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.TargetedCountries", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.TargetedCountries", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Countries", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.OriginCountries", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.OriginCountries", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Contents", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.AptAttachments", "AttachmentProp_Id", "dbo.AttachmentProps");
            DropForeignKey("dbo.AptAttachments", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.AlternativeNames", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.AlternativeNames", "Status_Id", "dbo.Status");
            DropIndex("dbo.TargetedCountries", new[] { "APT_id" });
            DropIndex("dbo.TargetedCountries", new[] { "Country_Id" });
            DropIndex("dbo.OriginCountries", new[] { "APT_id" });
            DropIndex("dbo.OriginCountries", new[] { "Country_Id" });
            DropIndex("dbo.AptAttachments", new[] { "AttachmentProp_Id" });
            DropIndex("dbo.AptAttachments", new[] { "APT_id" });
            DropIndex("dbo.ThreatSignatures", new[] { "APT_id" });
            DropIndex("dbo.Countries", new[] { "Status_Id" });
            DropIndex("dbo.Contents", new[] { "APT_id" });
            DropIndex("dbo.Status", new[] { "StatusType_id" });
            DropIndex("dbo.AlternativeNames", new[] { "APT_id" });
            DropIndex("dbo.AlternativeNames", new[] { "Status_Id" });
            DropTable("dbo.TargetedCountries");
            DropTable("dbo.OriginCountries");
            DropTable("dbo.AptAttachments");
            DropTable("dbo.StatusTypes");
            DropTable("dbo.ThreatSignatures");
            DropTable("dbo.Countries");
            DropTable("dbo.Contents");
            DropTable("dbo.AttachmentProps");
            DropTable("dbo.Status");
            DropTable("dbo.AlternativeNames");
            DropTable("dbo.APTs");
        }
    }
}
