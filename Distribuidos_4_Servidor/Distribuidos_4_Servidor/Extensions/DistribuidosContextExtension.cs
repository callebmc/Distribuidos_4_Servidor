using Bogus;
using Distribuidos.Persistence;
using Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Distribuidos.API.Extensions
{
    public static class DistribuidosContextExtension
    {
        public static async Task SeedData(this DistribuidosContext context, int qtdeRegistros = 10, CancellationToken ct = default)
        {
            if (context.Curriculos.Any())
                return;

            var curriculoFake = new Faker<Curriculo>()
                .RuleFor(p => p.nome, f => f.Name.FullName())
                .RuleFor(p => p.contato, (f, p) => f.Internet.Email(firstName: p.nome))
                .RuleFor(p => p.area, f => f.Name.JobArea())
                .RuleFor(p => p.carga_horaria, f => f.Random.Int())
                .RuleFor(p => p.salario_pretendido, f => f.Random.Double())
                .Generate(qtdeRegistros);

            if (context.Vagas.Any())
                return;

            var vagasFake = new Faker<Empresa>()
                .RuleFor(p => p.nomeEmpresa, f => f.Company.CompanyName())
                .RuleFor(p => p.emailEmpresa, (f, p) => f.Internet.Email(firstName: p.nomeEmpresa))
                .RuleFor(p => p.areaVaga, f => f.Name.JobArea())
                .RuleFor(p => p.cargaHorariaVaga, f => f.Random.Int())
                .RuleFor(p => p.salarioVaga, f => f.Random.Double())
                .Generate(qtdeRegistros);

            context.Vagas.AddRange(vagasFake);
            context.Curriculos.AddRange(curriculoFake);
            await context.SaveChangesAsync(ct);
        }
    }
}
