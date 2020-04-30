using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsMan.Data.Data;
using System;
using System.Linq;

namespace NewsMan.Data.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            const int NUM_OF_QUESTIONS = 8;

            using (var context = new NewsManDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<NewsManDbContext>>()))
            {
                // Look for any data first.
                if (context.Survey.Any())
                {
                    return;   // DB has been seeded
                }

                for (var x = 1; x < NUM_OF_QUESTIONS; x++)
                {
                    // loop y number of times for EACH question (x)
                    var q = new QMaster
                    {
                        Id = x
                    };

                    for (var y = 1; y < 100; y++)
                    {
                        int rnd = new Random().Next(1, 5);

                        context.Survey.AddRange(
                            new Survey
                            {
                                QMaster = q,
                                Answer = rnd
                            }

                        );
                        context.SaveChanges();
                    }


                }
            }
        }
    }
}