using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigationApp.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string CiUsuario { get; set; }
        public string NombresUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string DireccionUsuario { get; set; }
        public string TelefonoUsuario { get; set; }
        public string ContraseniaUsuario { get; set; }
    }
}
