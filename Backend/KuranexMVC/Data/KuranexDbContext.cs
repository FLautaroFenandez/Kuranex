using Microsoft.EntityFrameworkCore;
using KuranexMVC.Models;

namespace KuranexMVC.Data
{
    public class KuranexDbContext : DbContext
    {
        public KuranexDbContext(DbContextOptions<KuranexDbContext> options) : base(options)
        {
        }

        // Estas propiedades DbSet representan las tablas que se crearán en SQL Server
        public DbSet<Familiar> Familiares { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<RegistroSignoVital> RegistrosSignosVitales { get; set; }
    }
}