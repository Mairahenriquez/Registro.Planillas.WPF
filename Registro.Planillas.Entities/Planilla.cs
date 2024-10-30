using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Planillas.Entities
{
    [Table("PLANILLAS")]
    public class Planilla
    {
        [Key]
        int planilla_id { get; set; }
        DateTime fecha_planilla {  get; set; }
        double total_salarios { get; set; }
        double total_afp { get; set; }
        double total_isss { get; set; }
        double descuento_afp { get; set; }
        double descuento_isss { get; set; }
        double renta {  get; set; }
        int dias_laborados { get; set; }
        int horas_laboradas { get; set; }
    }
}
