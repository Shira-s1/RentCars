using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Core.DTOs
{
    public class OrdersDTO
    {
        public int NumOrder { get; set; }//מספר הזמנה
        public int ClientId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int CarId { get; set; }
       
    }
}
