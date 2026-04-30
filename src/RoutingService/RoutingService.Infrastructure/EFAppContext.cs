using Microsoft.EntityFrameworkCore;
using RoutingService.Domain;
using RoutingService.Infrastructure.ModelConfigurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelService.Infrastructure
{
    public class EFAppContext : DbContext
    {

        public DbSet<Terminal> Terminals { get; set; }

        public EFAppContext(DbContextOptions<EFAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TerminalConfiguration());
            modelBuilder.ApplyConfiguration(new EdgeConfiguration());
        }
    }
}
