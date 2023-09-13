using Empleados.Core.Modelos;
using Empleados.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Empleados.Infraestructura.Inicializador
{
    public class DbInicializador : IDbInicializador
    {
        private readonly ApplicationDbContext _db;

        public DbInicializador(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Inicializar()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (!_db.Compania.Any())
            {
                var companiaData = File.ReadAllText("../Empleados.Infraestructura/Data/SeedData/companias.json");
                var companias = JsonSerializer.Deserialize<List<Compania>>(companiaData);
                _db.Compania.AddRange(companias);
            }

            if (!_db.Empleado.Any())
            {
                var empleadoData = File.ReadAllText("../Empleados.Infraestructura/Data/SeedData/empleados.json");
                var empleados = JsonSerializer.Deserialize<List<Empleado>>(empleadoData);
                _db.Empleado.AddRange(empleados);
            }

            if (_db.ChangeTracker.HasChanges())
                _db.SaveChanges();
        }
    }
}
