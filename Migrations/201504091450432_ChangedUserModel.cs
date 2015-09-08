namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Salt", c => c.String());
        }
    }
}
