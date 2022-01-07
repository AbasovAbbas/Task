using CarSalesSystem.Data;
using CarSalesSystem.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesSystem.Data
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CarSalesDbContext>();
                InitCars(db);
            }
        }
        private static void InitCars(CarSalesDbContext db)
        {
            if (!db.Cars.Any())
            {
                db.Cars.AddRange(
                    new Car { Brand = "KIA", Model = "Optima", Price = 10000, Year = 2010  },
                    new Car { Brand = "Hyundai", Model = "Sonata", Price = 12000, Year = 2012 },
                    new Car { Brand = "Mercedes", Model = "E200", Price = 25000, Year = 2014 }
                );
                db.SaveChanges();
                Debug.Write("Seeded");
            }
        }
    }
}
