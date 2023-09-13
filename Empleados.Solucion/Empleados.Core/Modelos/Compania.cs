using System.ComponentModel.DataAnnotations;

namespace Empleados.Core.Modelos
{
    public class Compania
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la compañia es requerido")]
        [MaxLength(100, ErrorMessage = "El campo no debe ser mayor a 100")]
        public string NombreCompania { get; set; }

        [Required(ErrorMessage = "La dirección de la compañia es requerida")]
        [MaxLength(150, ErrorMessage = "El campo no debe ser mayor a 150")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El teléfono de la compañia es requerido")]
        [MaxLength(40, ErrorMessage = "El campo no debe ser mayor a 40")]
        public string Telefono { get; set; }

        [MaxLength(40, ErrorMessage = "El campo no debe ser mayor a 40")]
        public string Telefono2 { get; set; }
    }
}
