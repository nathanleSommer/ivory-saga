using IvorySaga.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace IvorySaga.Infrastructure.Data;

public class IvorySagaDataContext : DbContext
{
    public DbSet<Saga> Sagas { get; set; }
    public DbSet<Chapter> Chapter { get; set; }

    public IvorySagaDataContext(DbContextOptions<IvorySagaDataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }
}
