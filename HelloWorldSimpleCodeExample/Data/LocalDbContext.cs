using HelloWorldSimpleCodeExample.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldSimpleCodeExample.Data
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
        {
        }

        public DbSet<Quote> Quote { get; set; }
    }
}