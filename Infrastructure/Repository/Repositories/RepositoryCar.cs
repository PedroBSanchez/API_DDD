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

        public async Task<List<Car>> ListCar(string filter, string value, string userId)
        {
             
            var filterNumber = int.Parse(filter);

            var modelSearch = "";
            var nameSearch = "";
            

            switch (filterNumber)
            {
                case 1:
                    modelSearch = value;
                    break;

                case 2:
                    nameSearch = value;
                    break;

                default:
                    modelSearch = value;
                    break;
            }


            using (var db = new ContextBase(_OptionsBuilder) )
            {

                //AsNoTracking()
                return await db.Car.Where(x => x.Model.Contains(modelSearch)).Where(x => x.Name.Contains(nameSearch)).Where(x => x.UserId == userId).ToListAsync();
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
