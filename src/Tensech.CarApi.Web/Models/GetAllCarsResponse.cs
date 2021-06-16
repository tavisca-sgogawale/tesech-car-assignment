using System.Collections.Generic;
using Tensech.CarApi.Core.Models;
namespace Tensech.CarApi.Web.Models
{
    public class GetAllCarsResponse
    {

        public List<Car> Cars { get; set; }
        public Paging Paging { get; set; }
    }
}
