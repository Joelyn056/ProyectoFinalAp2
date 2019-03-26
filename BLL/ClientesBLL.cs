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
    public class ClientesBLL
    {
        public static bool Guardar(Clientes clientes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Clientes.Add(clientes);
                
                contexto.SaveChanges();
                paso = true;
                
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Modificar(Clientes clientes)
        {
            bool paso = true;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(clientes).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Clientes clientes = contexto.Clientes.Find(id);

                contexto.Clientes.Remove(clientes);
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

        public static Clientes Buscar(int id)
        {
            Clientes clientes = new Clientes();
            Contexto contexto = new Contexto();
            try
            {
                clientes = contexto.Clientes.Find(id);
                contexto.Dispose();
            }

            catch (Exception)
            {
                throw;
            }

            return clientes;
        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> expression)
        {

            List<Clientes> clientes = new List<Clientes>();
            Contexto contexto = new Contexto();

            try
            {
                clientes = contexto.Clientes.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return clientes;
        }
    }
}
