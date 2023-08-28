using Example2.NorthwindDB;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    internal class NorthwindContextFactory : IDesignTimeDbContextFactory<NorthwindContext>
    {
        static NorthwindContextFactory()
        {
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true)
               .Build();

            connectionString = config["ConnectionStrings:NorthwindConnection"];
            Console.WriteLine("ConnectionString:" + connectionString);
        }

        static string? connectionString = null;

        public NorthwindContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NorthwindContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new NorthwindContext(optionsBuilder.Options);
        }
    }

}
