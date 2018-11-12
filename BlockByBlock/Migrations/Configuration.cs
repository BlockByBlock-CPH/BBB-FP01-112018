namespace BlockByBlock.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlockByBlock.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BlockByBlock.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //IList<Models.Days> Days_Table = new List<Models.Days>();

            //Days_Table.Add(new Standard() { StandardName = "Standard 1", Description = "First Standard" });
            //Days_Table.Add(new Standard() { StandardName = "Standard 2", Description = "Second Standard" });
            //Days_Table.Add(new Standard() { StandardName = "Standard 3", Description = "Third Standard" });

            //context.Standards.AddRange(defaultStandards);

            //base.Seed(context);

            SeedDays(context);
        }

        private void SeedDays(Models.ApplicationDbContext context)
        {
            IList<Models.Days> Day_Table = new List<Models.Days>();

            Day_Table.Add(new Models.Days() { Id_Day = 1, Name_Day = "MONDAY" });
            Day_Table.Add(new Models.Days() { Id_Day = 2, Name_Day = "TUESDAY" });
            Day_Table.Add(new Models.Days() { Id_Day = 3, Name_Day = "WEDNESDAY" });
            Day_Table.Add(new Models.Days() { Id_Day = 4, Name_Day = "THURSDAY" });
            Day_Table.Add(new Models.Days() { Id_Day = 5, Name_Day = "FRIDAY" });
            Day_Table.Add(new Models.Days() { Id_Day = 6, Name_Day = "SATURDAY" });
            Day_Table.Add(new Models.Days() { Id_Day = 7, Name_Day = "SUNDAY" });


            context.Days_Table.AddRange(Day_Table);

            base.Seed(context);

        }
    }

    
}
