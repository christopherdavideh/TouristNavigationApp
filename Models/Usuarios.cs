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
        public int useId { get; set; }
        public string useCi { get; set; }
        public string useName { get; set; }
        public string useEmail { get; set; }
        public string useAddress { get; set; }
        public string usePhone { get; set; }
        public string usePassword { get; set; }
    }
}
