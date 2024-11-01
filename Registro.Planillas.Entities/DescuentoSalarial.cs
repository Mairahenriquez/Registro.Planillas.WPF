using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Planillas.Entities
{
    [Table("DESCUENTOS_SALARIALES")]
    public class DescuentoSalarial
    {
        [Key]
        public int descuento_id {  get; set; }
        public DateTime fecha { get; set; }
        public double monto {  get; set; }
        public string descripcion {  get; set; }
        public int empleado_id { get; set; }
    }
}
