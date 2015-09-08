namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        RecordId = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.RecordId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
