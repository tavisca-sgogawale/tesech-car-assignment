using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Core.Models;
using Tensech.CarApi.Services.Contract;

namespace Tensech.CarApi.Store
{
    public class CarMockStore :ICarStore
    {
        public static List<Car> cars = new List<Car>()
    {
        new Car("C101","Ciaz","Maruti Suzuki",CarType.Sedan, 850000,20),
        new Car("C102","Swift","Maruti Suzuki",CarType.Hatchback, 600000,21),
        new Car("C103","Swift","Maruti Suzuki",CarType.Hatchback, 600000,21),
        new Car("C104","Swift","Maruti Suzuki",CarType.Hatchback, 600000,21),
         new Car("C105","Swift","Maruti Suzuki",CarType.Hatchback, 600000,21),
        new Car("C106","Swift","Maruti Suzuki",CarType.Hatchback, 600000,21),
        new Car("C107","Swift","Maruti Suzuki",CarType.Hatchback, 600000,21),
    };

        public async Task<Car> AddCarAsync(Car car)
        {
            cars.Add(car);
            return await GetCarByIdAsync(car.Id);
        }

        public async Task DeleteCarByIdAsync(string id)
        {
            cars.Remove(cars.Find(x => x.Id == id));
           
        }

        public async Task<Core.Models.GetAllCarsResponse> GetAllCarsAsync(Paging paging)
        {
            return new Core.Models.GetAllCarsResponse()
            {
                Cars = cars,
                Paging = paging
            };
                
        }
        public async Task<Car> GetCarByIdAsync(string id)
        {
            return cars.Find(x => x.Id == id);
        }

        public async Task<Car> ModifyCarAsync(Car car)
        {
           var carToModiy = cars.Find(x => x.Id == car.Id);
            carToModiy = car;
            return cars.Find(x => x.Id == car.Id);

        }
    }
}

