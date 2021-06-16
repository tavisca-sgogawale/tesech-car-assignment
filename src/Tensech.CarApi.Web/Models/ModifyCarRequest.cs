using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tensech.CarApi.Web.Models
{
    public class ModifyCarRequest
    {
        public string AuthorizationToken { get; set; }
        public Car Car { get; set; }
    }
}
