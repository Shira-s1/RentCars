using System.Net;
using System.Security.Claims;
using System;
using RentCars.Interfaces;

namespace RentCars.Entities
{
    public class DataContext : IDataContext
    {
        public List<Car> carList { get; set; }
        public List<Client> clientList { get; set; }
        public List<Orders> orderList { get; set; }


        public DataContext()
        {
            carList = new List<Car>();
            clientList = new List<Client>();
            orderList = new List<Orders>();
        }
    }
}
