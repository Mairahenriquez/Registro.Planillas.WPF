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
        public int planilla_id { get; set; }
        public DateTime fecha_planilla {  get; set; }
        public double total_salarios { get; set; }
        public double total_afp { get; set; }
        public double total_isss { get; set; }
        public double descuento_afp { get; set; }
        public double descuento_isss { get; set; }
        public double renta {  get; set; }
        public int dias_laborados { get; set; }
        public int horas_laboradas { get; set; }
    }
}
