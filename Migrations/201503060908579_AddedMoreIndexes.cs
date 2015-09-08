namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreIndexes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Observations", "ClientMac");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Observations", new[] { "ClientMac" });
        }
    }
}
