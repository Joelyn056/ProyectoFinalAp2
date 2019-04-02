using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entidades;
using System.Linq.Expressions;

namespace BLL.Tests
{
    [TestClass()]
    public class FacturasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Facturas facturas = new Facturas();
            facturas.FacturaId = 0;
            facturas.NombreCliente = "juan";
            facturas.SubTotal = 55;
            facturas.Itbis = 50;
            facturas.Total = 105;
            paso = FacturasBLL.Guardar(facturas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Facturas facturas = new Facturas();
            facturas.FacturaId = 2;
            facturas.NombreCliente = "Jose";
            facturas.SubTotal = 40;
            facturas.Itbis = 30;
            facturas.Total = 70;
            paso = FacturasBLL.Modificar(facturas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso= false;
            paso = FacturasBLL.Eliminar(0);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
 
            Facturas facturas = new Facturas();
            facturas = FacturasBLL.Buscar(2);
            Assert.IsNotNull(facturas);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = BLL.FacturasBLL.GetList(f => true);
            Assert.IsNotNull(lista);
        }
    }
}