using RentCars.Core.Entities;
using RentCars.Core.Interfaces;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using RentCars.Data;

namespace RentCars.Service.Services
{
    public class RentingService :IRentingService
    {

        private readonly DataContext _dataContext;
        public RentingService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

      
        public IEnumerable<Car> Get()
        {
            return _dataContext.carList.ToList();
        }

        
        public Car Get(int id)//מחפש רכב ומציג אותו לפי ID
        {
            var car = _dataContext.carList.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return null;
            }
            return car;
        }

        
        //public void Post([FromBody] string value)
        public void Post(Car c)//-ליצור חדש ולהוסיף אותו להוסיף רכב להשכרה
        {
            if (c != null)
            _dataContext.carList.Add(c);
            _dataContext.SaveChanges();
        }

        
        //public void Put(int id, [FromBody] string value)
        public void Put(Car updatedCar)
        {
            var carToUpdate = _dataContext.carList.FirstOrDefault(c1 => c1.Id == updatedCar.Id);
            if (carToUpdate != null)
            {
                carToUpdate.Status = updatedCar.Status;
                carToUpdate.LicensePlate = updatedCar.LicensePlate;
                carToUpdate.Id = updatedCar.Id;
                carToUpdate.Cname = updatedCar.Cname;
                carToUpdate.Name = updatedCar.Name;
                carToUpdate.Price = updatedCar.Price;
                carToUpdate.Model = updatedCar.Model;
            }
            else
            {
                throw new Exception("Car not found");
            }
            _dataContext.SaveChanges();
        }

      
        // public void Delete(int id)
        public void Delete(int numOrder)//מוחק לפי מספר הזמנה
        {
            var orderToDelete = _dataContext.orderList.FirstOrDefault(o => o.NumOrder == numOrder);
            if (orderToDelete != null)
            {
                _dataContext.orderList.Remove(orderToDelete);
            }
            else
            {
                throw new Exception("Number of order not found");
            }
            _dataContext.SaveChanges();
        }
    }
}
