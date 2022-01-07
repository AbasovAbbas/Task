using CarSalesSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesSystem.Data
{
    public class CarSalesDbContext : DbContext
    {
        public CarSalesDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
