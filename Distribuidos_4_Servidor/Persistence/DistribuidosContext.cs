using Distribuidos.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistence.Configuration;
using System.Reflection;

namespace Distribuidos.Persistence
{
    public class DistribuidosContext : DbContext
    {
        public DistribuidosContext(DbContextOptions options) : base(options) { }

        protected DistribuidosContext() { }

        public DbSet<Empresa> Vagas { get; set; }
        public DbSet<Curriculo> Curriculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(CurriculoConfiguration)));
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(EmpresaConfiguration)));
            base.OnModelCreating(modelBuilder);
        }
    }
}
