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
    public class OrdersService :IRentingService
    {

        private readonly DataContext _dataContext;
        public OrdersService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

      
        public IEnumerable<Orders> Get()//מחזיר רשימת הזמנות
        {
            return _dataContext.orderList.ToList();
        }

        
        public Orders Get(int orderNum)//מחפש מספר הזמנה ומציג אותו לפי 
        {
            var order = _dataContext.orderList.FirstOrDefault(c => c.NumOrder == orderNum);
            if (order == null)
            {
                return null;
            }
            return order;
        }

        
        //public void Post([FromBody] string value)
        public void Post(Car c)//-ליצור חדש ולהוסיף אותו להוסיף רכב להשכרה
        {
            if (c != null)
            _dataContext.carList.Add(c);
            _dataContext.SaveChanges();
        }

        
        //public void Put(int id, [FromBody] string value)
        public void Put(Orders updatedOrder)//מעדכן פרטים בהזמנה
        {
            var orderToUpdate = _dataContext.orderList.FirstOrDefault(c1 => c1.NumOrder == updatedOrder.NumOrder);
            if (orderToUpdate != null)
            {
                orderToUpdate.NumOrder = updatedOrder.NumOrder;
                orderToUpdate.ClientId = updatedOrder.ClientId;
                orderToUpdate.DateFrom = updatedOrder.DateFrom;
                orderToUpdate.DateTo = updatedOrder.DateTo;
                orderToUpdate.CarId = updatedOrder.CarId;
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
