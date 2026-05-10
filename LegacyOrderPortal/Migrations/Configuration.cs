using System.Data.Entity.Migrations;
using LegacyOrderPortal.DAL;

namespace LegacyOrderPortal.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LegacyOrderPortal.DAL.LegacyOrderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LegacyOrderPortal.DAL.LegacyOrderContext";
        }

        protected override void Seed(LegacyOrderContext context)
        {
            // Seed data moved to initializer for legacy deployment patterns.
        }
    }
}
