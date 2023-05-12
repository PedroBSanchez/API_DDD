using AutoMapper;
using Domain.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIs.Models;

namespace WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        private readonly IMapper _IMapper;


        private readonly ICar _ICar;

        public CarController(IMapper IMapper, ICar ICar)
        {
            _IMapper = IMapper;
            _ICar = ICar;

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
            await _ICar.Add(carMap);

            return carMap.Notifications;


        }


        [Authorize]
        [Produces("application/json")]
        [HttpPut("/api/Update")]
        public async Task<List<Notifies>> Upate(CarViewModel car)
        {

            var carMap = _IMapper.Map<Car>(car);
            await _ICar.Update(carMap);

            return carMap.Notifications;


        }


        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/Delete")]
        public async Task<List<Notifies>> Delete(CarViewModel car)
        {

            var carMap = _IMapper.Map<Car>(car);
            await _ICar.Delete(carMap);
            return carMap.Notifications;


        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/GetEntityById")]
        public async Task<CarViewModel> GetEntityById(Car car)
        {

            car = await _ICar.GetEntityById(car.Id);
            var carMap = _IMapper.Map<CarViewModel>(car);
            return carMap;
           


        }


        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/List")]
        public async Task<List<CarViewModel>> List()
        {

            var cars = await _ICar.List();
            var carMap = _IMapper.Map<List<CarViewModel>>(cars);
            return carMap;



        }



    }
}
