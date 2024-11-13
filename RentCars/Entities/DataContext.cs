using System.Net;
using System.Security.Claims;
using System;

namespace RentCars.Entities
{
    public class DataContext
    {
        public static List<Car> carList = new List<Car>();
        public static List<Client> clientList = new List<Client>();
        public static List<Orders> orderList = new List<Orders>();


        static DataContext()
        {
            carList = new List<Car>();
            clientList = new List<Client>();
            orderList = new List<Orders>();
        }
    }
}
