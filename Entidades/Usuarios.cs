using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Entidades
{
    [Serializable]
    public class Usuarios
    {
        //Ojo verificar que mas se le puede poder o quitar
        [Key]
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string Contrasena { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Usuario = string.Empty;
            NombreUsuario = string.Empty;
            TipoUsuario = string.Empty;
            Contrasena = string.Empty;
        }

        public Usuarios(int usuarioId, string usuario, string nombreUsuario, string tipoUsuario, string contrasena)
        {
            UsuarioId = usuarioId;
            TipoUsuario = tipoUsuario;
            Contrasena = contrasena;
        }
    }
}
