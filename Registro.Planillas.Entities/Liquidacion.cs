using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Planillas.Entities
{
    [Table("LIQUIDACIONES")]
    public class Liquidacion
    {
        [Key]
        public int liquidacion_id { get; set; }
        public int empleado_id { get; set; }
        public DateTime fecha {  get; set; }
        public double indemnizacion { get; set; }
    }
}
