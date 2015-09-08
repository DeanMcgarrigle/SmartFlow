using SmartFlow.DataAccess;

namespace SmartFlow.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartFlowContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CommandTimeout = 180;
        }

        protected override void Seed(SmartFlowContext context)
        {

        }
    }
}
