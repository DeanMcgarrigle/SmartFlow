namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemovedEventTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Observations", "EventTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Observations", "EventTime", c => c.DateTime(nullable: false));
        }
    }
}
