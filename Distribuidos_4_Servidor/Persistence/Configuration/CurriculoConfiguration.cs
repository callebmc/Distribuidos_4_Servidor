using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Distribuidos.Persistence.Configuration
{
    public class CurriculoConfiguration : IEntityTypeConfiguration<Curriculo>
    {
        public void Configure(EntityTypeBuilder<Curriculo> builder)
        {
            builder.HasKey(p => p.id_curriculo);
            builder.Property(p => p.nome).IsRequired(true);
            builder.Property(p => p.contato).IsRequired(true);
            builder.Property(p => p.area).IsRequired(true);
            builder.Property(p => p.carga_horaria).IsRequired(true);
            builder.Property(p => p.salario_pretendido).IsRequired(true);
        }
    }
}
