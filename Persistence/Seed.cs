using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Activities.Any()) return;

            var activities = new List<Activity>
            {
                new Activity
                {
                    Title = "Past Activity 1",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Activity 2 months ago",
                    Category = "drinks",
                    City = "Sorocaba",
                    Venue = "São Paulo",

                },
                 new Activity
                {
                    Title = "Past Activity 2",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Activity 2 months ago",
                    Category = "drinks",
                    City = "Manaul",
                    Venue = "Amazonas",

                },
                  new Activity
                {
                    Title = "Past Activity 3",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Activity 2 months ago",
                    Category = "drinks",
                    City = "Guarulhos",
                    Venue = "São Paulo",

                },
                   new Activity
                {
                    Title = "Past Activity 4",
                    Date = DateTime.Now.AddMonths(-3),
                    Description = "Activity 3 months ago",
                    Category = "drinks",
                    City = "River Sul",
                    Venue = "São Paulo",

                },
                    new Activity
                {
                    Title = "Past Activity 5",
                    Date = DateTime.Now.AddMonths(-1),
                    Description = "Activity 1 months ago",
                    Category = "drinks",
                    City = "Pernambuco",
                    Venue = "Paraiba",

                },
            };

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();

        }
    }


}
