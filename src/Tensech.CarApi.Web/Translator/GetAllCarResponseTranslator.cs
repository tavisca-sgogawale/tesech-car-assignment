using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tensech.CarApi.Web.Models;

namespace Tensech.CarApi.Web
{
    public static class GetAllCarResponseTranslator
    {
        public static GetAllCarsResponse ToGetAllCarResponse(this Services.Contract.GetAllCarsResponse getAllCarsResponse)
        {
            if(getAllCarsResponse == null)
            {
                return null;
            }
            else
            {
                return new GetAllCarsResponse()
                {
                    Paging = new Paging{
                        PageNo = getAllCarsResponse.Paging.PageNo,
                        PageSize = getAllCarsResponse.Paging.PageSize,
                        TotalRecords = getAllCarsResponse.Paging.TotalRecords
                    },
                    Cars = getAllCarsResponse.Cars.Select(x => x.ToModel()).ToList()
                };

            }
        }


    }
}
