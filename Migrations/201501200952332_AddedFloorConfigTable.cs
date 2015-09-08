namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedFloorConfigTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FloorConfigs",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        X = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Y = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FloorConfigs");
        }
    }
}
