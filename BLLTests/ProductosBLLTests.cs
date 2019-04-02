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
    public class ProductosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Productos productos = new Productos();
            productos.ProductoId = 0;
            productos.Descripcion = "prote";           
            productos.FechaIngreso = DateTime.Now;
            paso = ProductosBLL.Guardar(productos);
            Assert.AreEqual(paso, true);

        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso = false;
            Productos productos = new Productos();
            productos.ProductoId = 2;
            productos.Descripcion = "supliyen";
            productos.FechaIngreso = DateTime.Now;
            paso = ProductosBLL.Modificar(productos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {          
            bool paso = false;
            paso = ProductosBLL.Eliminar(2);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            
            Productos productos = new Productos();
            productos = ProductosBLL.Buscar(2);
            Assert.IsNotNull(productos);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = BLL.ProductosBLL.GetList(p => true);
                Assert.IsNotNull(lista);
        }

    }
}