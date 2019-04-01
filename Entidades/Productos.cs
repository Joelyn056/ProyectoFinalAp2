using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Entidades
{
    [Serializable]
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Descripcion { get; set; }
        public Decimal Ganancias { get; set; }
        public Decimal Costo { get; set; }
        public Decimal Precio { get; set; }
        public int Inventario { get; set; }

        public Productos()
        {
            ProductoId = 0;
            FechaRegistro = DateTime.Now;
            Descripcion = string.Empty;
            Ganancias = 0;
            Costo = 0;
            Precio = 0;
            Inventario = 0;

        }

        public Productos(int productoId, DateTime fechaRegistro, string descripcion, decimal ganancias, decimal costo, decimal precio, int inventario)
        {
            ProductoId = productoId;
            FechaRegistro = fechaRegistro;
            Descripcion = descripcion;
            Ganancias = ganancias;
            Costo = costo;
            Precio = precio;
            Inventario = Inventario;
        }
    }
}
