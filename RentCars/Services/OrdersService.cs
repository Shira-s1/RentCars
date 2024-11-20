using RentCars.Entities;
using RentCars.Interfaces;

namespace RentCars.Services
{
    public class OrdersService
    {

        private readonly IDataContext _dataContext;
        public OrdersService(IDataContext dataContext) { _dataContext = dataContext; }
        public int Fine(DateTime dateTo)//קנס
        {
            DateTime currentDate = DateTime.Now;
            if (currentDate > dateTo)
                return 2000;
            return 0;
        }
        public void Change(int numOrder, DateTime dateFrom, DateTime dateTo)
        {
            var order = _dataContext.orderList.FirstOrDefault(c => c.NumOrder == numOrder);
            if (order != null)
            {
                order.NumOrder = numOrder;
                order.DateFrom = dateFrom;
                order.DateTo = dateTo;
            }
        }
        public void Delete(int numOrder)
        {
            var order = _dataContext.orderList.FirstOrDefault(c => c.NumOrder == numOrder);
            if (order != null)
            {
                _dataContext.orderList.Remove(order);

            }
        }
    }
}
