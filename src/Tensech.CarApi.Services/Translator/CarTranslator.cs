using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensech.CarApi.Services
{
    public static class CarTranslator
    {
        public static Core.Models.Car ToEntity(this Car car)
        {
            if (car == null)
                return null;
            return new Core.Models.Car()
            {
                Id = car.Id,
                Manufacturer = car.Manufacturer,
                Mileage = car.Mileage,
                Name = car.Name,
                Price = new Core.Models.Price(car.Price.Amount),
                Type = (Core.Models.CarType)Enum.Parse(typeof(CarType), car.Type.ToString())
            };
        }
        public static Car ToModel(this Core.Models.Car car)
        {
            if (car == null)
                return null;
            return new Car()
            {
                Id = car.Id,
                Manufacturer = car.Manufacturer,
                Mileage = car.Mileage,
                Name = car.Name,
                Price = new Price()
                {
                    Amount = car.Price.Amount,
                    Currency = car.Price.Currency
                },
            Type = (CarType)Enum.Parse(typeof(CarType), car.Type.ToString())
            };

        }
    }
}
