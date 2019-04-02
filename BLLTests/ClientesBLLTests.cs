using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
    [TestClass()]
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Clientes clientes = new Clientes();
            clientes.ClienteId = 1;
            clientes.Nombres = "Pedro";
            clientes.Sexo = "Masculino";
            clientes.Cedula = "77777777777";
            clientes.Direccion = "Santa ana";
            clientes.NumeroCelular = "21312312313";
            
            paso = ClientesBLL.Guardar(clientes);
            Assert.AreEqual(paso, true);

        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Clientes clientes = new Clientes();
            clientes.ClienteId = 2;
            clientes.Nombres = "Pedro javier";
            clientes.Sexo = "Masculino";
            clientes.Cedula = "8888888888";
            clientes.Direccion = "SFM";
            clientes.NumeroCelular = "434343434343";
            paso = ClientesBLL.Modificar(clientes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 2;
            bool paso;
            paso = ClientesBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 1;
            Clientes clientes = new Clientes();
            clientes = ClientesBLL.Buscar(id);
            Assert.IsNotNull(clientes);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = BLL.ClientesBLL.GetList(c => true);
            Assert.IsNotNull(lista);
        }
    }
}