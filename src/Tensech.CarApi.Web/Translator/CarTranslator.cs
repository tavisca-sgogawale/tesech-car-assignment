using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tensech.CarApi.Web
{
    public static class CarTranslator
    {
        public static Services.Car ToEntity(this Car car)
        {

            return new Services.Car()
            {
                Id = car.Id,
                Manufacturer = car.Manufacturer,
                Mileage = car.Mileage,
                Name = car.Name,
                Price = new Services.Price()
                {
                    Amount = car.Price
                },
                Type = car.Type.toCarType()
            };
        }
        public static Car ToModel(this Services.Car car)
        {
            if (car == null)
                return null;
            return new Car()
            {
                Id = car.Id,
                Manufacturer = car.Manufacturer,
                Mileage = car.Mileage,
                Name = car.Name,
                Price = car.Price.Amount,
                Type = car.Type.ToString()
            };

        }

        private static Services.CarType toCarType(this string type)
        {
            try
            {
                var carType = (Services.CarType)Enum.Parse(typeof(Services.CarType), type);
                return carType;
            }
            catch(Exception ex)
            {
                return Services.CarType.None;
            }

        }

    }
}
