using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    [Serializable]
   public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Edad { get; set; }
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
            Fecha = DateTime.Now.Date;
            Edad = string.Empty;
            Sexo = string.Empty;
            Ciudad = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Email = string.Empty;
        }

        public Clientes(int clienteId, string nombres, string edad, string sexo, string ciudad, string direccion, string telefono, string celular, string email)
        {
            ClienteId = clienteId;
            Nombres = nombres;
            Edad = edad; //oye la direccion no la guardas en el llenaclase es lo0 que pasa para alla iba cuando te dije esperate
            Sexo = sexo;
            Ciudad = ciudad;
            Direccion = direccion;
            Telefono = telefono;
            Celular = celular;
            Email = email;
        }
    }
}
