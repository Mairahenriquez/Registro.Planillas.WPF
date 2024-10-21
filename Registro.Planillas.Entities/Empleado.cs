using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro.Planillas.Entities
{
    [Table("EMPLEADOS")]
    public class Empleado
    {
        [Key]
        public int empleado_id { get; set; }
        public int empresa_id { get; set;}
        public int cargo_id { get; set; }
        public string dui { get; set;}
        public string nombres { get; set;}
        public string apellidos { get; set; }
        public float salario_base { get; set; }
        public string residencia { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_contrato { get; set; }
        public float descuento_afp { get; set; }
        public float descuento_isss { get; set; }
        public int horas_laboradas { get; set; }
        public int años_laborados { get; set; }
        public float descuento_renta { get; set; }
    }
}
