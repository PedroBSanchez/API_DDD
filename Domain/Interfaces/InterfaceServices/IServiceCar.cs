using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceCar
    {


        Task Add(Car Object);
        Task Update(Car Object);
        Task<List<Car>> ListCars(string filter, string value, string userId);
        Task<bool> DeleteById(int id);




    }
}
