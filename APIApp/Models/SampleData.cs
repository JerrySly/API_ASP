using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIApp.Models
{
    public static class SampleData
    {
        public static void Init(ApplicationContext context)
        {
 
                if (!context.Volunteers.Any())
                {
                    context.Volunteers.AddRange(
                        new Volunteer() { Name = "Sveta", Soname = "Hitryakova", Age = 20, ExpWork = 1, WorkForToday = "Cook" },
                        new Volunteer() { Name = "Nikita", Soname = "Ovechkin", Age = 19, ExpWork = 0, WorkForToday = "Dispanser" },
                        new Volunteer() { Name = "Andrew", Soname = "Ostapov", Age = 19, ExpWork = 1, WorkForToday = "Documents" }
                        );
                }
            
            if (!context.Homelesses.Any())
            {
                context.Homelesses.AddRange(
                    new Homeless() { Name="Igor", Soname="Orlov", Age=27, FullYearsWithoutHome=1,Known=true},
                     new Homeless() { Name = "Anastasia", Soname = "Berezova", Age = 32, FullYearsWithoutHome = 3, Known = false }
                );
            }
            if (!context.Services.Any())
            {
                context.Services.AddRange(
                    new Service() { NameOfService="Hot food", DurationInMinutes=20,ExpensesForCompany=120},
                     new Service() { NameOfService = "Stay at night", DurationInMinutes = 420, ExpensesForCompany = 150 },
                      new Service() { NameOfService = "Shower", DurationInMinutes = 20, ExpensesForCompany = 80 }
                      );
                
            }
            context.SaveChanges();
        }
    }
}
