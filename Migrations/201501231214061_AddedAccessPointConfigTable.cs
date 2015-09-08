namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedAccessPointConfigTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessPointConfigs",
                c => new
                    {
                        ApMac = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 128),
                        DisplayName = c.String(),
                        X = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Y = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.ApMac, t.Name });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccessPointConfigs");
        }
    }
}
