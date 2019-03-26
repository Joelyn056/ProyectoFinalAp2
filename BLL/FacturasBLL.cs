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
    public class FacturasBLL
    {
        public static bool Guardar(Facturas facturas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if(contexto.Facturas.Add(facturas) != null)
                {                 

                     contexto.SaveChanges();
                     paso = true;
                }
                                             
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Facturas facturas)
        {
            bool paso = true;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(facturas).State = EntityState.Detached;
                contexto.Entry(facturas).State = EntityState.Modified;

                foreach(var item in facturas.Detalle)
                {
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    if(facturas.Detalle.ToList().Exists(f => f.Id == item.Id))
                    {
                         contexto.Entry(item).State = estado;
                    }
                    else
                    {
                        contexto.FacturaDetalles.Add(item);
                    }                  
                    
                }

                contexto.SaveChanges();
                paso = true;
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Facturas facturas = contexto.Facturas.Find(id);
                              

                contexto.FacturaDetalles.RemoveRange(contexto.FacturaDetalles.Where(d => d.FacturaId == id));
                contexto.Facturas.Remove(facturas);
                contexto.SaveChanges();
                paso = true;
               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Facturas Buscar(int id)
        {
            Facturas facturas = null;
            Contexto contexto = new Contexto();
            try
            {
                facturas = contexto.Facturas.Find(id);

                if(facturas != null)
                {
                    facturas.Detalle.Count();

                    foreach(var item in facturas.Detalle)
                    {
                        string p = item.Producto.Descripcion;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return facturas;
        }

        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> expression)
        {

            List<Facturas> list = new List<Facturas>();
            Contexto contexto = new Contexto();

            try
            {
                list = contexto.Facturas.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return list;
        }

        public static List<FacturaDetalles> List(Expression<Func<FacturaDetalles, bool >> expression)
        {
            List<FacturaDetalles> list = new List<FacturaDetalles>();
            Contexto contexto = new Contexto();

            try
            {
                list = contexto.FacturaDetalles.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return list;
        }

        //Calculos
        public static Decimal CalcularGanancias(Decimal precio, Decimal costo)
        {
            return (((precio - costo) / costo) * 100);
        }

        public static Decimal CalcularPrecio(Decimal costo, Decimal ganancia)
        {
            ganancia /= 100;
            ganancia *= costo;
            return costo + ganancia;
        }

        public static Decimal CalcularImporte(Decimal cantidad, Decimal precio)
        {
            return cantidad * precio;
        }

        public static Decimal CalcularSubTotal(Decimal importe)
        {
            return importe;
        }

        public static Decimal CalcularItbis(Decimal subtotal)
        {
            return subtotal * (decimal)0.18;
        }

        public static Decimal CalcularTotal(Decimal subtotal, Decimal itbis)
        {
            return subtotal + itbis;
        }

        public static Decimal CalcularDevuelta(Decimal efectivo, Decimal total)
        {
            return efectivo - total;
        }



    }
}
