using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
   public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }


        public Clientes()
        {
            ClienteId = 0;
            Nombres = string.Empty;
            Fecha = DateTime.Now;
            Edad = 0;
            Sexo = string.Empty;
            Ciudad = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Email = string.Empty;
        }

        public Clientes(int clienteId, string nombres, int edad, string sexo, string ciudad, string direccion, string telefono, string celular, string email)
        {
            ClienteId = clienteId;
            Nombres = nombres;
            Edad = edad;
            Sexo = sexo;
            Ciudad = ciudad;
            Direccion = direccion;
            Telefono = telefono;
            Celular = celular;
            Email = email;
        }
    }
}
