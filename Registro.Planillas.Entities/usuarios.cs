using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Planillas.Entities
{
    public class usuarios
    {
        [Key]
        public int PK_codigo { get; set; }

        public string usuario { get; set; }
        public string nombre { get; set; }
        public string clave { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public int FK_estado { get; set; }
        public int FK_rol { get; set; }

        public string confirmClave;
    }
}
