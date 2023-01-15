using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IvorySaga.Infrastructure.Persistence.Configurations
{
    public class SagaConfiguration : IEntityTypeConfiguration<Saga>
    {
        public void Configure(EntityTypeBuilder<Saga> builder)
        {
            ConfigureSagaTable(builder);
            ConfigureChapterTable(builder);
        }

        private void ConfigureSagaTable(EntityTypeBuilder<Saga> builder)
        {
            builder.ToTable("saga");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("SagaId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => SagaId.Create(value));

            builder.OwnsOne(x => x.Author);

            builder.Metadata.FindNavigation(nameof(Saga.Chapters))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureChapterTable(EntityTypeBuilder<Saga> builder)
        {
            builder.OwnsMany(s => s.Chapters, sb =>
            {
                sb.ToTable("chapter");

                sb.WithOwner().HasForeignKey("SagaId");

                sb.HasKey("Id", "SagaId");
                    
                sb.Property(x => x.Id)
                .HasColumnName("ChapterId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => ChapterId.Create(value));
            });
        }
    }
}
