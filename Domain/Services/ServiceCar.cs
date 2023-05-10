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

    }
}
