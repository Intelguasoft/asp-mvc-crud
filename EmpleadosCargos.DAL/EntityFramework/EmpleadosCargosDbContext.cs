using EmpleadosCargos.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosCargos.DAL.EntityFramework
{
    public class EmpleadosCargosDbContext : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cargo> Cargos { get; set; }

        public EmpleadosCargosDbContext() : base("name=EmpleadosCargosDBConnectionString")
        {

        }
    }
}
