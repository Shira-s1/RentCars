using RentCars.Core.Entities;
using RentCars.Core.Interfaces;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;


namespace RentCars.Service.Services
{
    public class RentingService :IRentingService
    {

        //private readonly IDataContext _dataContext;
        //public RentingService(IDataContext dataContext) { _dataContext = dataContext; }
        //public int Fine(DateTime dateTo)//קנס
        //{
        //    DateTime currentDate = DateTime.Now;
        //    if (currentDate > dateTo)
        //        return 2000;
        //    return 0;
        //}
        //public void Change(int numOrder, DateTime dateFrom, DateTime dateTo)
        //{
        //    var order = _dataContext.orderList.FirstOrDefault(c => c.NumOrder == numOrder);
        //    if (order != null)
        //    {
        //        order.NumOrder = numOrder;
        //        order.DateFrom = dateFrom;
        //        order.DateTo = dateTo;
        //    }
        //}
        //public void Delete(int numOrder)
        //{
        //    var order = _dataContext.orderList.FirstOrDefault(c => c.NumOrder == numOrder);
        //    if (order != null)
        //    {
        //        _dataContext.orderList.Remove(order);

        //    }
        //}
        private readonly IDataContext _dataContext;
        public RentingService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

      
        public IEnumerable<Car> Get()
        {
            return _dataContext.carList;
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
           
        }

        
        //public void Put(int id, [FromBody] string value)
        public void Put(int id, Car updatedCar)
        {
            var carToUpdate = _dataContext.carList.FirstOrDefault(c1 => c1.Id == id);
            if (carToUpdate == null)
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
        }
    }
}
