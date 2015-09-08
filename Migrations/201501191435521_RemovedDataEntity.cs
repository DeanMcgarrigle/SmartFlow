namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDataEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Floors", "ApMac", "dbo.Data");
            DropForeignKey("dbo.Observations", "ApMac", "dbo.Data");
            DropIndex("dbo.Floors", new[] { "ApMac" });
            DropIndex("dbo.Observations", new[] { "ApMac" });
            AlterColumn("dbo.Observations", "ApMac", c => c.String());
            DropTable("dbo.Data");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        ApMac = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ApMac);
            
            AlterColumn("dbo.Observations", "ApMac", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Observations", "ApMac");
            CreateIndex("dbo.Floors", "ApMac");
            AddForeignKey("dbo.Observations", "ApMac", "dbo.Data", "ApMac");
            AddForeignKey("dbo.Floors", "ApMac", "dbo.Data", "ApMac", cascadeDelete: true);
        }
    }
}
