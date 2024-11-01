using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Planillas.Entities
{
    [Table("PRESTACIONES")]
    public class Prestacion
    {
        [Key]
        int prestacion_id {  get; set; }
        int empleado_id { get; set; }
        string descripcion {  get; set; }
        double monto { get; set; }
        DateTime fecha { get; set; }
    }
}
