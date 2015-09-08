namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccessPointConfigs", "IsActive", c => c.Boolean(nullable: false));
            Sql("UPDATE dbo.AccessPointConfigs SET IsActive = 1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccessPointConfigs", "IsActive");
        }
    }
}
