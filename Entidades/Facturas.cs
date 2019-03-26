using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entidades
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set;}
        public int ClienteId { get; set;}
        public DateTime Fecha { get; set;}
        public Decimal SubTotal { get; set;}
        public Decimal Itbis { get; set;}
        public Decimal Total { get; set;}
        public virtual List<FacturaDetalles> Detalle { get; set; }

        public Facturas()
        {
            Detalle = new List<FacturaDetalles>();
        }
        /// Metodo de la para
        public Facturas(int facturaId, int clienteId, DateTime fecha, decimal subTotal, decimal itbis, decimal total, List<FacturaDetalles> detalle)
        {
            FacturaId = facturaId;
            ClienteId = clienteId;
            Fecha = fecha;
            SubTotal = subTotal;
            Itbis = itbis;
            Total = total;
            Detalle = detalle;
        }
    }
}
