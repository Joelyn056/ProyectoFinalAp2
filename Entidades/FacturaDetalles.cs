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
    public class FacturaDetalles
    {
        [Key]
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Importe { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }

        public FacturaDetalles()
        {
            Id = 0;
            FacturaId = 0;
            ProductoId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

        public FacturaDetalles(int id, int facturaId, int productoId, string descripcion, int cantidad, decimal precio, decimal importe)
        {
            Id = id;
            FacturaId = facturaId;
            ProductoId = productoId;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }


}
