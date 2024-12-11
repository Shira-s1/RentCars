using RentCars.Core.Interfaces;

namespace RentCars.Core.Entities
{
    public class FakeDataContext:DataContext
    {
        public  List<Car> carList { get; set; }
        public  List<Client> clientList { get; set; }
        public  List<Orders> orderList { get; set; }



        public FakeDataContext()
        {
            carList = new List<Car>();
            clientList = new List<Client>();
            orderList = new List<Orders>();
        }
    }
}
