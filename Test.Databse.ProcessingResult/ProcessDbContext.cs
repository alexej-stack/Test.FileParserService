using Microsoft.EntityFrameworkCore;

namespace Test.Database.ProcessingResult;

public class ProcessDbContext : DbContext
{
	public DbSet<ModuleData> ProcessData { get; set; }

	public ProcessDbContext()
	{
	}

	public ProcessDbContext(DbContextOptions<ProcessDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<ModuleData>(entity =>
		{
			entity.ToTable("ProcessData");
			entity.HasKey(e => e.Id);
			entity.Property(e => e.ModuleCategoryID).IsRequired();
			entity.Property(e => e.ModuleState).IsRequired().HasConversion<string>();

			/**********************************************************************************************/
		});
	}
}