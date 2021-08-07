﻿namespace FitnessAppLibrary.BL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FitnessAppLibrary.BL.Controller.FitnessContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "FitnessAppLibrary.BL.Controller.FitnessContext";

        }

        protected override void Seed(FitnessAppLibrary.BL.Controller.FitnessContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
