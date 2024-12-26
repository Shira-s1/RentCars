using RentCars.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Core.Interfaces
{
    public interface IRentingService
    {
    
        public IEnumerable<Car> Get();
        public Car Get(int id);
        public void Post(Car c);
        public void Put(Car updatedCar);
        public void Delete(int numOrder);
    }
}
