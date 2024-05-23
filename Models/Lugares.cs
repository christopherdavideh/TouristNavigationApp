using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigationApp.Models
{
    public class Lugares
    {
        public int plaId { get;set; }
        public string plaName { get;set;}
        public string plaDetail { get;set; }
        public string plaReference { get;set; }
        public double plaLatitude { get;set; }
        public double plaLongitude { get;set; }
        public string plaCity { get;set; }
        public string plaProvince { get;set; }
    }
}
