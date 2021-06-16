using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Services.Contract;

namespace Tensech.CarApi.Services
{
    public static class GetAllCarsResponseTranslator
    {
        public static GetAllCarsResponse ToGetAllCarResponse(this Core.Models.GetAllCarsResponse response)
        {
            
                return new GetAllCarsResponse()
                {
                    Cars = response.Cars.Select(x => x.ToModel()).ToList(),
                    Paging = response.Paging.ToModel()
                    
                };
        }
        public static GetCarResponse ToGetCarResponse(this Core.Models.Car car)
        {
            if (car == null)
            {
                return null;
            }
            else
            {
                return new GetCarResponse()
                {
                    Car = car.ToModel()
                };

            }
        }

        public static AddCarResponse ToAddCarResponse(this Core.Models.Car car)
        {
            if (car == null)
            {
                return null;
            }
            else
            {
                return new AddCarResponse()
                {
                    Car = car.ToModel()
                };

            }

        }

        public static ModifyCarResponse ToModifyCarResponse(this Core.Models.Car car)
        {
            if (car == null)
            {
                return null;
            }
            else
            {
                return new ModifyCarResponse()
                {
                    Car = car.ToModel()
                };

            }

        }

    }
}
