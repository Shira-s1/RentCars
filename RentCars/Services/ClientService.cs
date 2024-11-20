using RentCars.Entities;
using RentCars.Interfaces;

namespace RentCars.Services
{
    public class ClientService
    {
        private readonly IDataContext _dataContext;
        public ClientService(IDataContext dataContext) { _dataContext = dataContext; }
        public void Update(string phoneNumber) {
            var client = _dataContext.clientList.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
            if (client != null) {
                client.PhoneNumber = phoneNumber;
            }

        }
        public void Delete(int id, string name, string phoneNumber, int LicenseNumber) {
            var client = _dataContext.clientList.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
            if (client != null) {
                _dataContext.clientList.Remove(client);
            }
        }
    }
}
