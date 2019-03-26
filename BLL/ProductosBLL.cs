using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using DAL;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace BLL
{
    public class ProductosBLL : Repositorio<ProductosBLL>
    {
        public  bool Guardar(Productos productos)
        {

            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Productos.Add(productos) != null)
                {
                    /*Productos productos = BLL.ProductosBLL.Buscar(productos.ProductoId);*/
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Modificar(Productos productos)
        {
            bool paso = true;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(productos).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Productos productos = contexto.Productos.Find(id);

                contexto.Productos.Remove(productos);
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }

            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static Productos Buscar(int id)
        {
            Productos productos = new Productos();
            Contexto contexto = new Contexto();
            try
            {
                productos = contexto.Productos.Find(id);
                contexto.Dispose();
            }

            catch (Exception)
            {
                throw;
            }

            return productos;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> expression)
        {

            List<Productos> productos = new List<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                productos = contexto.Productos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return productos;
        }

        public static decimal CalculaCosto(decimal Ganancia, decimal Precio)
        {
            Ganancia /= 100;
            return Convert.ToDecimal(Precio) * Convert.ToDecimal(Ganancia);
        }

        public static decimal CalcularPrecio(decimal Costo, decimal Ganancia)
        {
            Ganancia /= 100;
            Ganancia *= Costo;
            return Convert.ToDecimal(Costo) + Convert.ToDecimal(Ganancia);

        }

        public static Decimal CalcularImporte(decimal cantidad, decimal precio)
        {
            return cantidad * precio;
        }

        public static Decimal CalcularSubtotal(decimal importe)
        {
            return importe;
        }

        public static Decimal CalcularItbis(decimal subtotal)
        {
            return subtotal * (decimal)0.18;
        }

        public static Decimal CalcularTotal(decimal subtotal, decimal itbis)
        {
            return subtotal + itbis;
        }

        public static Decimal CalcularGanancias(Decimal precio, Decimal costo)
        {
            return (((precio - costo) / costo) * 100);
        }
    }
}
