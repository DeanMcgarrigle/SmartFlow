namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedDashboardConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DashboardConfigs",
                c => new
                    {
                        RecordId = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        MinimumObservations = c.Int(nullable: false),
                        MaximumUnc = c.Int(nullable: false),
                        MinimumAccessPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DashboardConfigs");
        }
    }
}
