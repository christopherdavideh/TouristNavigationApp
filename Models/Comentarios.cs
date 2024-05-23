using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigationApp.Models
{
    public class Comentarios
    {
        public int comId { get; set; }
        public string comDetail { get; set; }
        public int comScore { get; set; }
        public Usuarios fkUser { get; set; }
        public Lugares fkPlace { get; set; }
    }
}
