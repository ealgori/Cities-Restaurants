using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCore.DesignTimeFactory
{
    public class EfContextFactory:IDesignTimeDbContextFactory<EfContext>
    {
        public EfContextFactory() {}
        public EfContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings:RestaurantCS");
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("The connection string was not set " +
                                                    "in the 'ConnectionStrings:RestaurantCS' environment variable.");

            var options = new DbContextOptionsBuilder<EfContext>()
                .UseSqlServer(connectionString)
                .Options;
            return new EfContext(options);

        }
    }
}