namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedSeenTimeIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Observations", "SeenTime");
        }

        public override void Down()
        {
            DropIndex("dbo.Observations", new[] { "SeenTime" });
        }
    }
}
