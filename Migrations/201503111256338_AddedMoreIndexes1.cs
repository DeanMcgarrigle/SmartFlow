namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreIndexes1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
USE [SmartFlow]
GO
CREATE NONCLUSTERED INDEX [IX_SeenTime_ClientMac]
ON [dbo].[Observations] ([SeenTime])
INCLUDE ([ClientMac])
GO
");
        }
        
        public override void Down()
        {

        }
    }
}
