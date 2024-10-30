using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Planillas.Entities
{
    [Table("FAMILIARES")]
    public class Familiares
    {
        [Key]
        public int familiar_id { get; set; }
        public string nombres { get; set; }
        public string apellidos {  get; set; }
        public int empleado_id { get; set; }
        public string residencia { get; set; }
        public string telefono {  get; set; }
    }
}
