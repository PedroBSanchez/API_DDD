using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceCar : IServiceCar
    {

        private readonly ICar _ICar;

        public ServiceCar(ICar ICar)
        {
            _ICar = ICar;

        }

        public async Task Add(Car Object)
        {

            var isValidCarModel = Object.isValidStringProperty(Object.Model, "Model");
            var isValaidCarYear = Object.isValidIntProperty(Object.Year, "Year");
            
            if (isValidCarModel && isValaidCarYear) { 
        
                await _ICar.Add(Object);
            }

        }

        public async Task<bool> DeleteById(int id)
        {


            return await _ICar.DeleteById(id);
        }

        public async  Task<List<Car>> ListCars(string filter, string value, string userId)
        {

            return await _ICar.ListCar(filter, value, userId);
           
        }

        public async Task Update(Car Object)
        {
            var isValidCarModel = Object.isValidStringProperty(Object.Model, "Model");
            var isValaidCarYear = Object.isValidIntProperty(Object.Year, "Year");

            if (isValidCarModel && isValaidCarYear)
            {

                await _ICar.Update(Object);
            }
        }
    }
}
