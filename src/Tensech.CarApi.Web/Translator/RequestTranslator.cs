using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Web.Models;
using Tensech.CarApi.Common;

namespace Tensech.CarApi.Web
{
    public static class RequestTranslator
    {
        public static Services.Contract.GetAllCarsRequest GetServiceRequest(this GetAllCarsRequest req)
        {
            if (req == null || req.Paging == null)
            {
                return new Services.Contract.GetAllCarsRequest()
                {
                    Paging = new Services.Paging()
                    {
                        PageNo = KeyStore.Paging.PageNo,
                        PageSize = KeyStore.Paging.PageSize
                    },
                };
            }
            return new Services.Contract.GetAllCarsRequest()
            {
                Paging = req.Paging?.toEntity(),
            };
        }
        public static Services.Contract.ModifyCarRequest GetServiceRequest(this ModifyCarRequest req)
        {
            return new Services.Contract.ModifyCarRequest()
            {
                Car = req.Car.ToEntity()
            };
        }
        public static Services.Contract.AddCarRequest GetServiceRequest(this AddCarRequest req)
        {
            return new Services.Contract.AddCarRequest()
            {
                Car = req.Car.ToEntity()
            };
        }

        public static Services.Paging toEntity(this Paging paging)
        {
            return new Services.Paging
            {
                PageNo = paging.PageNo,
                PageSize = paging.PageSize,
                TotalRecords = paging.TotalRecords

            };
        }

        public static Paging toModel(this Services.Paging paging)
        {
            return new Paging
            {
                PageNo = paging.PageNo,
                PageSize = paging.PageSize,
                TotalRecords = paging.TotalRecords

            };
        }



    }
}
