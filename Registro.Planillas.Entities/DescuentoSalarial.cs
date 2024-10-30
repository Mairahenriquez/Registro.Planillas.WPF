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
        int descuento_id {  get; set; }
        DateTime fecha { get; set; }
        double monto {  get; set; }
        string descripcion {  get; set; }
        int empleado_id { get; set; }
    }
}
