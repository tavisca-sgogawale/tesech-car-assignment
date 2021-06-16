using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tensech.CarApi.Web.Models
{

    public class Paging
    {
        public long TotalRecords { get; set; }

        public int PageNo { get; set; }

        public int PageSize { get; set; }
    }

}
