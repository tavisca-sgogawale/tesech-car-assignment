using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tensech.CarApi.Common;
using Tensech.CarApi.Services.Contract;

namespace Tensech.CarApi.Web.Controllers
{
    [TypeFilter(typeof(UserAuthorizationFilter))]
    [Route("/api/car/v1.0")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        private ICarService _carService { get; }

        [HttpPost("cars")]
        public async Task<IActionResult> GetAllCarsAsync([FromBody] Models.GetAllCarsRequest request )
        {
            var result = await _carService.GetAllCarsAsync(request.GetServiceRequest());
            return Ok(result.ToGetAllCarResponse());
        }

        [HttpGet("cars/{carId}")]
        public async Task<IActionResult> GetCarByIdAsync([FromRoute] string carId)
        {

            var result = await _carService.GetCarByIdAsync(carId);
            return Ok(result);
        }


        [HttpPost("cars/add")]
        public async Task<IActionResult> AddCarAsync([FromBody] Models.AddCarRequest request)
        {
            Validations.EnsureValid(request, new AddCarRequestValidator());
            var result = await _carService.AddCarAsync(request.GetServiceRequest());
            return Ok(result);
        }

        [HttpPut("cars/update")]
        public async Task<IActionResult> ModifyCarAsync([FromBody] Models.ModifyCarRequest request)
        {
            Validations.EnsureValid(request, new ModifyCarRequestValidator());
            var result = await _carService.ModifyCarAsync(request.GetServiceRequest());
            return Ok(result);
        }

        [HttpDelete("cars/delete/{carId}")]
        public async Task<IActionResult> DeleteCarAsync([FromRoute] string carId)
        {
            await _carService.DeleteCarByIdAsync(carId);
            return Ok();
        }
    }
}