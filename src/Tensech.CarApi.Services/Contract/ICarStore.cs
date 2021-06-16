using System.Collections.Generic;
using System.Threading.Tasks;
using Tensech.CarApi.Core.Models;

namespace Tensech.CarApi.Services.Contract
{
    public interface ICarStore
    {
        Task<Core.Models.GetAllCarsResponse> GetAllCarsAsync(Core.Models.Paging paging);
        Task<Core.Models.Car> GetCarByIdAsync(string id);
        Task<Core.Models.Car> AddCarAsync(Core.Models.Car car);
        Task DeleteCarByIdAsync(string id);
        Task<Core.Models.Car> ModifyCarAsync(Core.Models.Car car);
    }
}