namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        ApMac = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ApMac);
            
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        ApMac = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Name, t.ApMac })
                .ForeignKey("dbo.Data", t => t.ApMac, cascadeDelete: true)
                .Index(t => t.ApMac);
            
            CreateTable(
                "dbo.FloorLocations",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        ApMac = c.String(nullable: false, maxLength: 128),
                        LocationRecordId = c.Guid(nullable: false),
                        X = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Y = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Name, t.ApMac, t.LocationRecordId })
                .ForeignKey("dbo.Locations", t => t.LocationRecordId, cascadeDelete: true)
                .ForeignKey("dbo.Floors", t => new { t.Name, t.ApMac }, cascadeDelete: true)
                .Index(t => new { t.Name, t.ApMac })
                .Index(t => t.LocationRecordId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        RecordId = c.Guid(nullable: false),
                        Lat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Lng = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unc = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Observations", t => t.RecordId, cascadeDelete: true)
                .Index(t => t.RecordId);
            
            CreateTable(
                "dbo.Observations",
                c => new
                    {
                        RecordId = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        ClientMac = c.String(),
                        Ipv4 = c.String(),
                        Ipv6 = c.String(),
                        SeenTime = c.DateTime(nullable: false),
                        SeenEpoch = c.Int(nullable: false),
                        Ssid = c.String(),
                        Rssi = c.Int(nullable: false),
                        Manufacturer = c.String(),
                        Os = c.String(),
                        ApMac = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Data", t => t.ApMac)
                .Index(t => t.ApMac);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Observations", "ApMac", "dbo.Data");
            DropForeignKey("dbo.Locations", "RecordId", "dbo.Observations");
            DropForeignKey("dbo.Floors", "ApMac", "dbo.Data");
            DropForeignKey("dbo.FloorLocations", new[] { "Name", "ApMac" }, "dbo.Floors");
            DropForeignKey("dbo.FloorLocations", "LocationRecordId", "dbo.Locations");
            DropIndex("dbo.Observations", new[] { "ApMac" });
            DropIndex("dbo.Locations", new[] { "RecordId" });
            DropIndex("dbo.FloorLocations", new[] { "LocationRecordId" });
            DropIndex("dbo.FloorLocations", new[] { "Name", "ApMac" });
            DropIndex("dbo.Floors", new[] { "ApMac" });
            DropTable("dbo.Observations");
            DropTable("dbo.Locations");
            DropTable("dbo.FloorLocations");
            DropTable("dbo.Floors");
            DropTable("dbo.Data");
        }
    }
}
