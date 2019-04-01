using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<FacturaDetalles> FacturaDetalles { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
      
        public Contexto():base("ConStr") 
        { 

        }
    }
}
