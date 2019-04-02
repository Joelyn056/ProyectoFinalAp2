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
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = 2;
            usuario.Nombres = "Joelyn de la rosa";
            usuario.NombreUsuario = "joe02";
            usuario.Clave = "polo12";
            usuario.Cargo = "admin";
            paso = UsuariosBLL.Guardar(usuario);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Usuarios usuario = new Usuarios();
            usuario.UsuarioId = 1;
            usuario.Nombres = "Joelyn payano";
            usuario.NombreUsuario = "joe05";
            usuario.Clave = "polo14";
            usuario.Cargo = "user";
            paso = UsuariosBLL.Guardar(usuario);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 1;
            bool paso;
            paso = UsuariosBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Usuarios usuario = new Usuarios();
            usuario = UsuariosBLL.Buscar(id);
            Assert.IsNotNull(usuario);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = BLL.UsuariosBLL.GetList(u => true);
            Assert.IsNotNull(lista);
        }
    }
}