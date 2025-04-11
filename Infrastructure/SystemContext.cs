using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenantDotNet9.Models;

namespace MultiTenantDotNet9.Infrastructure
{
    public class SystemContext: DbContext
    {
        public SystemContext(DbContextOptions options) : base(options)
        {


        }

        public SystemContext() : base()
        {

        }
        public DbSet<Category> Category { get; set; }   


    }

    public class DbContextFactory : IDesignTimeDbContextFactory<SystemContext>
    {
        public SystemContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SystemContext>();
            string conn = @"Server=MyServer;Initial Catalog=tenant2;Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true";
            optionsBuilder.UseSqlServer(conn);

            return new SystemContext(optionsBuilder.Options);
        }
    }
}
