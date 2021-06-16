using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tensech.CarApi.Services;

namespace Tensech.CarApi.Services.Contract
{
    public class GetAllCarsResponse
    {
        public Paging Paging { get; set; }
        public List<Car> Cars { get; set; }
    }
}
