using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using TerminalService.Domain.Entities;
using TerminalService.Infrastructure.ModelConfigurations;

namespace TerminalService.Infrastructure
{
	public class EFAppContext : DbContext
	{
		public DbSet<Terminal> Terminals { get; set; }
		public DbSet<TerminalAllocation> TerminalAllocations { get; set; }

		public EFAppContext(DbContextOptions<EFAppContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new TerminalConfiguration());
			modelBuilder.ApplyConfiguration(new TerminalAllocationConfiguration());
		}
	}
}
