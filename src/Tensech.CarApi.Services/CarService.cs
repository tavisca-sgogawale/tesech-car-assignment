    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Services.Contract;

namespace Tensech.CarApi.Services
{
    public class CarService : ICarService
    {
        private ICarStore _store;
            public CarService(ICarStore store)
            {
            _store = store;
            }

        public async Task<AddCarResponse> AddCarAsync(AddCarRequest request)
        {
            var result = await _store.AddCarAsync(request.Car.ToEntity());
            return result.ToAddCarResponse();
        }

        public async Task DeleteCarByIdAsync(string id)
        {
            await _store.DeleteCarByIdAsync(id);
        }

        public async Task<GetAllCarsResponse> GetAllCarsAsync(GetAllCarsRequest request)
        {

            var result = await _store.GetAllCarsAsync(request.Paging.ToEntity());
            return result.ToGetAllCarResponse();
        }

        public async Task<GetCarResponse> GetCarByIdAsync(string id)
        {
            var result = await _store.GetCarByIdAsync(id);
            return result.ToGetCarResponse();
        }

        public async Task<ModifyCarResponse> ModifyCarAsync(ModifyCarRequest request)
        {
            var result = await _store.ModifyCarAsync(request.Car.ToEntity());
            return result.ToModifyCarResponse();
        }
    }
}
