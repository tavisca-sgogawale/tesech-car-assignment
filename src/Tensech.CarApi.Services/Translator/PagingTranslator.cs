using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensech.CarApi.Services
{
    public static class PagingTranslator
    {
        public static Paging ToModel(this Core.Models.Paging paging)
        {
            return new Paging
            {
                PageNo = paging.PageNo,
                PageSize = paging.PageSize,
                TotalRecords = paging.TotalRecords
            };
        }

        public static Core.Models.Paging ToEntity(this Paging paging)
        {
            return new Core.Models.Paging
            {
                PageNo = paging.PageNo,
                PageSize = paging.PageSize,
                TotalRecords = paging.TotalRecords
            };
        }
    }
}
