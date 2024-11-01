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
        public DbSet<Familiares> familiares { get; set; }
        public DbSet<DescuentoSalarial> descuentosSalariales { get; set; }
        public DbSet<EmpleadosPlanillas> empleadosPlanillas { get; set; }
        public DbSet<Empresa> empresas {  get; set; }
        public DbSet<Liquidacion> liquidaciones {  get; set; }
        public DbSet<Planilla> planillas { get; set; }
        public DbSet<Prestacion> prestaciones { get; set; }
    }
}
