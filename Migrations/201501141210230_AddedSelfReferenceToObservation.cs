namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedSelfReferenceToObservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Observations", "ObservationRecordId", c => c.Guid());
            CreateIndex("dbo.Observations", "ObservationRecordId");
            AddForeignKey("dbo.Observations", "ObservationRecordId", "dbo.Observations", "RecordId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Observations", "ObservationRecordId", "dbo.Observations");
            DropIndex("dbo.Observations", new[] { "ObservationRecordId" });
            DropColumn("dbo.Observations", "ObservationRecordId");
        }
    }
}
