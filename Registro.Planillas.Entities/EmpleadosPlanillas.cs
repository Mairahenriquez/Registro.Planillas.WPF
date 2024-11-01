using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Planillas.Entities
{
    [Table("EMPLEADOS_PLANILLAS")]
    public class EmpleadosPlanillas
    {
        [Key]
        public int pk_codigo {  get; set; }
        public double aporte_afp { get; set; }
        public double aporte_isss {  get; set; }
        public int planilla_id {  get; set; }
        public int empleado_id { get; set; }
    }
}
