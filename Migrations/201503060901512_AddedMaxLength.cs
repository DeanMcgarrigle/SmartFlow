namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Observations", "ClientMac", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Observations", "ClientMac", c => c.String());
        }
    }
}
