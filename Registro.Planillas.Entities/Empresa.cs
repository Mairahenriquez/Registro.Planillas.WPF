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
        int empresa_id { get; set; }
        string nombre {  get; set; }
        string telefono { get; set; }
        string documento { get; set; }
        string numero_patronal { get; set; }
    }
}
