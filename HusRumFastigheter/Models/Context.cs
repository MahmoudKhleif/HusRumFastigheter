using Microsoft.EntityFrameworkCore;

namespace HusRumFastigheter.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)

        {

        }
        public DbSet<FastigheterController> fastigheterControllers { get; set; }
        public DbSet<Door> doors{ get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Tenant> tenants { get; set; }

    }
}
