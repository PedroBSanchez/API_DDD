using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryCar : GenericRepository<Car>, ICar
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositoryCar() 
        { 
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Car>> ListCar()
        {
            using (var db = new ContextBase(_OptionsBuilder) )
            {
                return await  db.Car.AsNoTracking().ToListAsync();
            }
        }

        public async Task<bool> DeleteById(int id)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                Car carToDelete = await this.FindById(id);

                if (carToDelete == null)
                {
                    return false;
                }

                db.Car.Remove(carToDelete);
                await db.SaveChangesAsync();

                return true;
            }
        }


        public async Task<Car> FindById(int id)
        {
            using (var db = new ContextBase(_OptionsBuilder))
            {
                return await db.Car.FirstAsync(x => x.Id == id);
            }
        }

       
    }
}
