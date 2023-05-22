using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICar : IGeneric<Car>
    {

        //Task<List<Car>> ListCar(Expression<Func<Car, bool>> exCar);
        Task<List<Car>> ListCar(string filter, string value, string userId);

        Task<bool> DeleteById(int id);

        Task<Car> FindById(int id);


    }
}
