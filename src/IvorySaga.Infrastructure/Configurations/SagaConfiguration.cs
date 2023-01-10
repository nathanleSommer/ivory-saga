using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IvorySaga.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IvorySaga.Infrastructure.Configurations
{
    public class SagaConfiguration : IEntityTypeConfiguration<Saga>
    {
        public void Configure(EntityTypeBuilder<Saga> builder)
        {
            ConfigureSagaTable(builder);
            ConfigureChapterTable(builder);
        }

        private void ConfigureChapterTable(EntityTypeBuilder<Saga> builder)
        {
            builder.ToTable("saga");
            builder.HasKey(s => s.Id);
        }

        private void ConfigureSagaTable(EntityTypeBuilder<Saga> builder)
        {
            throw new NotImplementedException();
        }
    }
}
