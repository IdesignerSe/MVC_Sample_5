using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Sample_1
{
    public class VehicleContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = optionsBuilder.UseSqlServer(
            @"Data Source = S5D011\SQLEXPRESS; Initial Catalog = AssetsCatalogWA;" +
            " Integrated Security = True; Connect Timeout = 30; Encrypt = False;" +
            " TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"
        );
        }
    }
}

