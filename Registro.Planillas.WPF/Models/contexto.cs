using Registro.Planillas.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Planillas.WPF.Models
{
    public class contexto : DbContext
    {
        public contexto() : base("Conexion")
        {

        }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Cargo> cargos { get; set; }
    }
}
