using System.Collections.Generic;
using ProductHunt.Data.Entity;

namespace ProductHunt.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductHunt.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductHunt.Data.ApplicationDbContext context)
        {
            var categories = new List<Category>()
            {
                new Category{Name = "Sport"},
                new Category{Name = "Hemelektronik"},
                new Category{Name = "Leksaker"},
            };
            categories.ForEach(p => context.Categories.AddOrUpdate(p));
            context.SaveChanges();
            var articles = new List<Article>()
            {
                new Article()
                {
                    Name = "Elcykel Allegro",
                    Number = "39533028",
                    Description = "En smart och tillförlitlig elcykel för dam från Batavus utmärkt både för långa och kortare turer.",
                    CategoryId = categories.First(p => p.Name == "Sport").Id,
                    Price = 18499 - Convert.ToDecimal((18499 *12.5)/100),
                    PriceWithVAT = 18499,
                },
                new Article()
                {
                    Name = "Lapierre Overvolt Urban 300",
                    Number = "40266837",
                    Description = "Praktisk och bekväm elcykel med upprätt körställning",
                    CategoryId = categories.First(p => p.Name == "Sport").Id,
                    Price = 20990 - Convert.ToDecimal((20990 *12.5)/100),
                    PriceWithVAT = 20990,
                },
                new Article()
                {
                    Name = "Chrome cast 2nd generationen",
                    Number = "p35372817",
                    Description = "Visar film eller annan media från mobilen på TV:n",
                    CategoryId = categories.First(p => p.Name == "Hemelektronik").Id,
                    Price = 390 -Convert.ToDecimal((390 *12.5)/100),
                    PriceWithVAT = 390,
                },
                new Article()
                {
                    Name = "Apple TV 64GB 4th generation",
                    Number = "35552289",
                    Description = "Nu kommer App Store till din tv. Du kan förvänta dig massor av spännande spel.",
                    CategoryId = categories.First(p => p.Name == "Hemelektronik").Id,
                    Price = 1990 - Convert.ToDecimal((1990 *12.5)/100),
                    PriceWithVAT = 1990,
                },
                 new Article()
                {
                    Name = "Big Foot truck 2wd",
                    Number = "40151785",
                    Description = "Det här är bilen som startade alltihop och skapade den idag enorma monster-truck trenden.",
                    CategoryId = categories.First(p => p.Name == "Leksaker").Id,
                    Price = 2795 - Convert.ToDecimal((2795 *12.5)/100),
                    PriceWithVAT = 2795,
                }
            };

            articles.ForEach(p => context.Articles.AddOrUpdate(p));
            context.SaveChanges();
        }
    }
}
