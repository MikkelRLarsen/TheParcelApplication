using Microsoft.EntityFrameworkCore;
using RoutingService.Domain;
using RoutingService.Infrastructure.ModelConfigurations;

namespace RoutingService.Infrastructure
{
    public class EFAppContext : DbContext
    {
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Edge> Edges { get; set; }

        public EFAppContext(DbContextOptions<EFAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TerminalConfiguration());
            modelBuilder.ApplyConfiguration(new EdgeConfiguration());
        }
    }
}
