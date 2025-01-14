using RentCars.Core.Entities;
using RentCars.Core.Interfaces;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using RentCars.Data;
using AutoMapper;
using RentCars.Core.DTOs;

namespace RentCars.Service.Services
{
    public class OrdersService : IOrdersService
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public OrdersService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        //1 
        public List<OrdersDTO> Get()//- ללא מספר אשראי מחזיר רשימת הזמנות
        {
            var orders = _dataContext.orderList.ToList();
            return _mapper.Map<List<OrdersDTO>>(orders);
        }

        //2
        public OrdersDTO Get(int orderNum)//מחפש מספר הזמנה ומציג אותו לפי 
        {
            var order = _dataContext.orderList.FirstOrDefault(c => c.NumOrder == orderNum);
            if (order == null)
            {
                return null;
            }
            //return order;
            return _mapper.Map<OrdersDTO>(order);//מחזיר את ההזמנה בלי מספר אשראי
        }


        //public void Post([FromBody] string value)
        public void Post(Orders o)//ליצור הזמנה חדשה
        {
            if (o != null)
                _dataContext.orderList.Add(o);
            _dataContext.SaveChanges();
        }


        //public void Put(int id, [FromBody] string value)
        //  public void Put(Orders updatedOrder)//לפני שינוי DTO
       
        //3
        public void Put(OrdersDTO updatedOrder)//מעדכן פרטים בהזמנה
        {
            var orderToUpdate = _dataContext.orderList.FirstOrDefault(c1 => c1.NumOrder == updatedOrder.NumOrder);
            if (orderToUpdate != null)
            {
                orderToUpdate.NumOrder = updatedOrder.NumOrder;
                orderToUpdate.ClientId = updatedOrder.ClientId;
                orderToUpdate.DateFrom = updatedOrder.DateFrom;
                orderToUpdate.DateTo = updatedOrder.DateTo;
                orderToUpdate.CarId = updatedOrder.CarId;
                // orderToUpdate.CreditCardNumber = updatedOrder.CreditCardNumber;
                //orderToUpdate.PaymentMethod = updatedOrder.PaymentMethod;

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
