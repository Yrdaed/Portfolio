using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Data;
using System;
using System.Linq;

namespace Portfolio.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PortfolioContext(serviceProvider.GetRequiredService<DbContextOptions<PortfolioContext>>()))
            {
                // Look for any data.
                if (context.Parameters.Any())
                {
                    return;   // DB has been seeded
                }

                context.Parameters.AddRange(
                    new Parameter
                    {
                        ParameterKey = "SiteTitle",
                        ParameterValue = "Paul Penetro"
                    },
                    new Parameter
                    {
                        ParameterKey = "SubTitle",
                        ParameterValue = "Mon sous-titre"
                    }
                );

                context.Users.AddRange(
                    new User
                    {
                        Login = "deadry",
                        Password = "P@ssw0rd"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}