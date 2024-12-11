using RentCars.Core.Entities;
using RentCars.Core.Interfaces;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using RentCars.Data;
namespace RentCars.Service.Services
{
    public class ClientService :IClientService
    {

        private readonly DataContext _dataContext;
        public ClientService(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }

       // private readonly ClientService _clientService;
        public List<Client> Get()
        {
            return _dataContext.clientList;
        }


        public Client Get(int id)
        {
            var client1 = _dataContext.clientList.FirstOrDefault(t => t.Id == id);
            if (client1 == null)
            {
                return null;
            }

            return client1;
        }


        public void Post(Client c)
        {
            _dataContext.clientList.Add(c);
        }


        public void UpdateClient(int id, Client updatedClient)
        {
            Client existingClient = _dataContext.clientList.FirstOrDefault(c1 => c1.Id == updatedClient.Id);
            if (existingClient != null)
            {
                existingClient.Id = updatedClient.Id;
                existingClient.Name = updatedClient.Name;
                existingClient.PhoneNumber = updatedClient.PhoneNumber;
                existingClient.LicenseNumber = updatedClient.LicenseNumber;

            }
            else
            {
                throw new Exception("Client not found");
            }
        }

        public void Delete(int id)
        {
            var clientToDelete = _dataContext.clientList.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                _dataContext.clientList.Remove(clientToDelete);
            }

        }
    }
}
