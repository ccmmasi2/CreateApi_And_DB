using Empleados.Core.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empleados.Infraestructura.Configuracion
{
    public class EmpleadoConfiguracion : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder) 
        {
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Apellidos).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Nombres).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Cargo).IsRequired().HasMaxLength(100);
            builder.Property(e => e.CompaniaId).IsRequired();

            builder.HasOne(e => e.Compania).WithMany().HasForeignKey(e => e.CompaniaId);
        }
    }
}
