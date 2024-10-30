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
        int liquidacion_id { get; set; }
        int empleado_id { get; set; }
        DateTime fecha {  get; set; }
        double indemnizacion { get; set; }
    }
}
