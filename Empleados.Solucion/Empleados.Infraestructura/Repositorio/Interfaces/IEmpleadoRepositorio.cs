using Empleados.Core.Modelos;

namespace Empleados.Infraestructura.Repositorio.Interfaces
{
    public interface IEmpleadoRepositorio : IRepositorio<Empleado>
    {
        void Actualizar(Empleado empleado);
    }
}
