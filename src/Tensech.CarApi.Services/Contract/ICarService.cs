using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Services.Contract;

namespace Tensech.CarApi.Services.Contract
{
    public interface ICarService
    {
        Task<GetAllCarsResponse> GetAllCarsAsync(GetAllCarsRequest request);
        Task<GetCarResponse> GetCarByIdAsync(string id);
        Task<AddCarResponse> AddCarAsync(AddCarRequest request);
        Task<ModifyCarResponse> ModifyCarAsync(ModifyCarRequest request);
        Task DeleteCarByIdAsync(string id); 
    }
}
