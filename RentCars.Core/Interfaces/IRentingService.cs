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
    
        public IEnumerable<Orders> Get();
        public Orders Get(int orderNum);
        public void Post(Car c);
        public void Put(Orders updatedOrder);
        public void Delete(int numOrder);
    }
}
