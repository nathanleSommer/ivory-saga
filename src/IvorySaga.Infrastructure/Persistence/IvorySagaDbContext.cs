using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.Entities;
using Microsoft.EntityFrameworkCore;

namespace IvorySaga.Infrastructure.Persistence;

public class IvorySagaDbContext : DbContext
{
    public DbSet<Saga> Sagas { get; set; } = null!;
    public DbSet<Chapter> Chapters { get; set; } = null!;

    public IvorySagaDbContext(DbContextOptions<IvorySagaDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(IvorySagaDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
