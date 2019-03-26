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
        public string Contraseña { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Usuario = string.Empty;
            NombreUsuario = string.Empty;
            TipoUsuario = string.Empty;
            Contraseña = string.Empty;
        }

        public Usuarios(int usuarioId, string usuario, string nombreUsuario, string tipoUsuario, string contraseña)
        {
            UsuarioId = usuarioId;
            TipoUsuario = tipoUsuario;
            Contraseña = contraseña;
        }
    }
}
