using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Planillas.Entities
{
    [Table("EMPRESAS")]
    public class Empresa
    {
        [Key]
        public int empresa_id { get; set; }
        public string nombre {  get; set; }
        public string telefono { get; set; }
        public string documento { get; set; }
        public string numero_patronal { get; set; }
    }
}
