namespace WeShouldGo.Migrations
{
    using Models;
    using Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WeShouldGo.Models.SearchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WeShouldGo.Models.SearchContext context)
        {
            var searches = new List<Search>
            {
                new Search
                {
                    Term = "Burgers",
                    Location = "Minneapolis, MN"
                }
            };

            searches.ForEach(s => context.Search.AddOrUpdate(l => l.Location, s));
            context.SaveChanges();
        }
    }
}
