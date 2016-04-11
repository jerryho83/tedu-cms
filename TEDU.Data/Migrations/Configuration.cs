namespace TEDU.Data.Migrations
{
    using Common;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TEDU.Data.TEDUEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TEDU.Data.TEDUEntities context)
        {

        }
    }
}