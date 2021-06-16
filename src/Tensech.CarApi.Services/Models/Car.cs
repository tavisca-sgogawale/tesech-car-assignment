using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensech.CarApi.Services   
{
    public class Car
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public CarType? Type { get; set; }
        public Price Price { get; set; }
        public double Mileage { get; set; }
    }
}
