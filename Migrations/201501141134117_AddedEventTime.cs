namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedEventTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Observations", "EventTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Observations", "EventTime");
        }
    }
}
