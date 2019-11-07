using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Persistence.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder) {

            //ID
            builder.HasKey(p => p.id_vaga);

            //Nome da empresa
            builder.Property(p => p.nomeEmpresa).IsRequired(true);

            //Email da empresa
            builder.Property(p => p.emailEmpresa).IsRequired(true);

            //Area da vaga
            builder.Property(p => p.areaVaga).IsRequired(true);

            //Carga horaria da vaga
            builder.Property(p => p.cargaHorariaVaga).IsRequired(true);

            //Salario da vaga
            builder.Property(p => p.salarioVaga).IsRequired(true);
        }
    }
}
