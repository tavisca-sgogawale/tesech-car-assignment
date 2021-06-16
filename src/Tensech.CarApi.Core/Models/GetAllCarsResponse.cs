using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensech.CarApi.Core.Models
{
    public class GetAllCarsResponse
    {
        public List<Car> Cars { get; set; }
        public Paging Paging { get; set; }
    }
}
