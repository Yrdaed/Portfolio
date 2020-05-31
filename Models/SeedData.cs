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
                        ParameterName = "My site title",
                        ParameterValue = "Site Title"
                    },
                    new Parameter
                    {
                        ParameterKey = "SubTitle",
                        ParameterName = "My site subtitle",
                        ParameterValue = "Sub Title"
                    },
                    new Parameter
                    {
                        ParameterKey = "NavTitle",
                        ParameterName = "My nav title",
                        ParameterValue = "Nav Title"
                    },
                    new Parameter
                    {
                        ParameterKey = "Section1",
                        ParameterName = "Section 1",
                        ParameterValue = "Section 1"
                    },
                    new Parameter
                    {
                        ParameterKey = "Section2",
                        ParameterName = "Section 2",
                        ParameterValue = "Section 2"
                    },
                    new Parameter
                    {
                        ParameterKey = "Section3",
                        ParameterName = "Section 3",
                        ParameterValue = "Section 3"
                    },
                    new Parameter
                    {
                        ParameterKey = "PrimButton",
                        ParameterName = "Main Button",
                        ParameterValue = "Main Button"
                    },
                    new Parameter
                    {
                        ParameterKey = "CVButton",
                        ParameterName = "My CV Button",
                        ParameterValue = "My CV"
                    },
                    new Parameter
                    {
                        ParameterKey = "AboutTitle",
                        ParameterName = "About Title",
                        ParameterValue = "About"
                    },
                    new Parameter
                    {
                        ParameterKey = "AboutText",
                        ParameterName = "About Text",
                        ParameterValue = "About Text"
                    },
                    new Parameter
                    {
                        ParameterKey = "Project1Title",
                        ParameterName = "Project 1 Title",
                        ParameterValue = "Project 1"
                    },
                    new Parameter
                    {
                        ParameterKey = "Project2Title",
                        ParameterName = "Project 2 Title",
                        ParameterValue = "Project 2"
                    },
                    new Parameter
                    {
                        ParameterKey = "Project3Title",
                        ParameterName = "Project 3 Title",
                        ParameterValue = "Project 3"
                    },
                    new Parameter
                    {
                        ParameterKey = "Project1Text",
                        ParameterName = "My first project description",
                        ParameterValue = "Description of a project"
                    },
                    new Parameter
                    {
                        ParameterKey = "Project2Text",
                        ParameterName = "My second project description",
                        ParameterValue = "Description of a project"
                    },
                    new Parameter
                    {
                        ParameterKey = "Project3Text",
                        ParameterName = "My third project description",
                        ParameterValue = "Description of a project"
                    },
                    new Parameter
                    {
                        ParameterKey = "Address",
                        ParameterName = "My address",
                        ParameterValue = "3 Castle Organa, Alderaan"
                    },
                    new Parameter
                    {
                        ParameterKey = "Email",
                        ParameterName = "My email address",
                        ParameterValue = "foo@bar.com"
                    },
                    new Parameter
                    {
                        ParameterKey = "Phone",
                        ParameterName = "My phone number",
                        ParameterValue = "00 00 00 00 00"
                    }

                );

                context.Users.AddRange(
                    new User
                    {
                        Login = "Admin",
                        Password = "P@ssw0rd"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}