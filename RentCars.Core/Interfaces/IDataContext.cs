using RentCars.Core.Entities;


namespace RentCars.Core.Interfaces
{
    public interface IDataContext
    {
        List<Car> carList { get; set; }
        List<Client> clientList { get; set; }
        List<Orders> orderList { get; set; }



    }
}
