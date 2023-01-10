using IvorySaga.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace IvorySaga.Infrastructure.DataContext;

public class IvorySagaDataContext : DbContext
{
    public DbSet<Saga> Sagas { get; set; } = null!;
    public DbSet<Chapter> Chapters { get; set; } = null!;

    public IvorySagaDataContext(DbContextOptions<IvorySagaDataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }
}
