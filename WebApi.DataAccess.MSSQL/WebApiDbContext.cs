using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess.MSSQL.Configurations;
using WebApi.DataAccess.MSSQL.Entities;

namespace WebApi.DataAccess.MSSQL
{
    public class WebApiDbContext : DbContext
    {

        public WebApiDbContext(DbContextOptions<WebApiDbContext> options): base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}