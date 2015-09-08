namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRelatedObservation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Observations", "ObservationRecordId", "dbo.Observations");
            DropIndex("dbo.Observations", new[] { "ObservationRecordId" });
            DropColumn("dbo.Observations", "ObservationRecordId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Observations", "ObservationRecordId", c => c.Guid());
            CreateIndex("dbo.Observations", "ObservationRecordId");
            AddForeignKey("dbo.Observations", "ObservationRecordId", "dbo.Observations", "RecordId");
        }
    }
}
