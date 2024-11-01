using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Planillas.Entities
{
    [Table("CARGOS")]
    public class Cargo
    {
        [Key]
        public int cargo_id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
