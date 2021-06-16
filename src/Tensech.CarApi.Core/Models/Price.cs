using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensech.CarApi.Core.Models
{
    public class Price
    {

        public Price(int amount)
        {
            Amount = amount;
            Currency = "INR";
        }

        public int Amount { get; set; }
        public string Currency { get; set; }
    }
}
