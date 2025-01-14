using RentCars.Core.DTOs;
using RentCars.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Core.Interfaces
{
    public interface IOrdersService
    {

        public List<OrdersDTO> Get();
        public OrdersDTO Get(int orderNum);
        public void Post(Orders c);
        public void Put(OrdersDTO updatedOrder);//מעדכן פרטים בהזמנה
        public void Delete(int numOrder);
    }
}
