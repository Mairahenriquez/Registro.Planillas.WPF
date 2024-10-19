using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Planillas.Entities
{
    class usuarios_roles
    {
        [Key]
        public int PK_codigo { get; set; }
        public string nombre { get; set; }
    }
}
