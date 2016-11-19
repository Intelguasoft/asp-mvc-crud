using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosCargos.Core
{
    [Table("Empleados")]
    public class Empleado
    {
        public Empleado()
        {

        }

        public int EmpleadoID { get; set; }

        [Required(ErrorMessage = "Debe introducir un Nombre")]
        [MaxLength(10, ErrorMessage = "El Nombre no puede ser mayor a 10 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe introducir un Apellido")]
        [MaxLength(15, ErrorMessage = "El Apellido no puede ser mayor a 15 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe introducir una Fecha")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [Required()]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
    }
}
