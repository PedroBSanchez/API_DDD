using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly IMapper _IMapper;


        private readonly ICar _ICar;

        private readonly IServiceCar _ServiceCar;

        public CarController(IMapper IMapper, ICar ICar, IServiceCar IServiceCar)
        {
            _IMapper = IMapper;
            _ICar = ICar;
            _ServiceCar = IServiceCar;

        }


        private async Task<string> ReturnLoggerUserId()
        {
            if (User != null)
            {

           
                var idUser = User.FindFirst("idUser");
      
                return idUser.Value;
                
            }

            return string.Empty;
        }


        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/Add")]
        public async Task<List<Notifies>> Add(CarViewModel car)
        {

            car.UserId = await ReturnLoggerUserId();
          

            

            var carMap = _IMapper.Map<Car>(car);
            //await _ICar.Add(carMap);
            await _ServiceCar.Add(carMap);

            return carMap.Notifications;


        }


        [Authorize]
        [Produces("application/json")]
        [HttpPut("/api/Update")]
        public async Task<List<Notifies>> Upate(CarViewModel car)
        {
            car.UserId = await ReturnLoggerUserId();

            var carMap = _IMapper.Map<Car>(car);
            // await _ICar.Update(carMap);
            await _ServiceCar.Update(carMap);
            return carMap.Notifications;


        }


        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {



            //var carMap = _IMapper.Map<Car>(car);
            var deleteCar = await _ServiceCar.DeleteById(id);

            if (!deleteCar)
            {
                return NotFound();
            }
            return Ok(deleteCar);
            


        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/GetEntityById/{id}")]
        public async Task<CarViewModel> GetEntityById(int id)
        {

            Car car = await _ICar.GetEntityById(id);
            var carMap = _IMapper.Map<CarViewModel>(car);
            return carMap;
          
        }


        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/ListCustom/{filter}")]
        public async Task<ActionResult<List<Car>>> List(string filter, [FromQuery] string? filterValue)
        {


   

            var value = "";

            if (filterValue != null) { 
                value = filterValue;
            }


            //var cars = await _ICar.List();
            //var carMap = _IMapper.Map<List<CarViewModel>>(cars);
            //return carMap;
            
            var userId = await ReturnLoggerUserId();

            List<Car> carList = await _ServiceCar.ListCars(filter, value, userId);

            return Ok(carList);



        }



    }
}
