using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosCargos.Core
{
    [Table("Cargos")]
    public class Cargo
    {
        public Cargo()
        {

        }
   

        public int CargoID { get; set; }

        [Required(ErrorMessage = "Debe introducir un Nombre")]
        [MaxLength(15, ErrorMessage = "El Nombre no puede ser mayor a 15 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe introducir un Importe")]
        [Range(typeof(decimal), "0", "9999999", ErrorMessage = "El Importe debe ser un valor entre 0 y 9999999")]
        public decimal Sueldo { get; set; }
    }
}