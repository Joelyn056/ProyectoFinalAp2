using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using DAL;
using Entidades;

namespace BLL
{
    public class FacturaRepositorio : Repositorio<Facturas>
    {
        public override Facturas Buscar(int id)
        {
            Facturas facturas = new Facturas();
            Contexto contexto = new Contexto();

            try
            {
                facturas = contexto.Facturas.Find(id);

                if(facturas != null)
                {
                    facturas.Detalle.Count();
                    foreach (var item in facturas.Detalle)
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

        public override bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Ant = contexto.Facturas.Find(id);
                if (Ant != null)
                {
                    contexto.FacturaDetalles.RemoveRange(contexto.FacturaDetalles.Where(x => x.FacturaId == Ant.FacturaId));
                    contexto.Entry(Ant).State = EntityState.Deleted;

                    if (contexto.SaveChanges() > 0)
                    {
                        paso = true;
                    }
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                contexto.Dispose();
            }



            return paso;
        }

        public override List<Facturas> GetList(Expression<Func<Facturas, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Facturas> lista = new List<Facturas>();
            try
            {
                lista = contexto.Facturas.Where(expression).ToList();
                foreach (var item in lista)
                {
                    item.Detalle.Count();
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

            return lista;
        }


        public override bool Guardar(Facturas entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Facturas.Add(entity) != null)
                {

                    foreach (var item in entity.Detalle)
                    {
                        contexto.Productos.Find(item.ProductoId).Inventario -= item.Cantidad;
                    }

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

        public override bool Modificar(Facturas factura)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var FacturaAnt = contexto.Facturas.Find(factura.FacturaId);

                foreach (var item in FacturaAnt.Detalle)
                {
                   
                    if (!factura.Detalle.ToList().Exists(f => f.Id == item.Id))
                    {
                        item.Producto = null;
                        contexto.Productos.Find(item.ProductoId).Inventario += item.Cantidad;

                    }
                }

                foreach (var item in factura.Detalle)
                {
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                contexto.Entry(factura).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
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

    }
}
