using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensech.CarApi.Web
{
    public class Car
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public double Mileage { get; set; }

       public Car()
        {
        }
    }
}
