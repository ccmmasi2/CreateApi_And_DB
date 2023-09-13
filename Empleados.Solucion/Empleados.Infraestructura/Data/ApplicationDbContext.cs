using Empleados.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Empleados.Infraestructura.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { }

        public DbSet<Compania> Compania { get; set; }
        public DbSet<Empleado> Empleado { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
