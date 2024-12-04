using RentCars.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Core.Interfaces
{
    public interface ICarService
    {
        public List<Car> GetCars();
        public Car GetSearch(int id);
        public void AddCar(Car newCar);
        public void UpdateCar(Car updatedCar);
        public void Delete(int id);
    }
}
