using RentCars.Core.Entities;
using RentCars.Core.Interfaces;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using RentCars.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AutoMapper;
using RentCars.Core.DTOs;

namespace RentCars.Service.Services
{
    public class ClientService :IClientService
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public ClientService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext; 
            _mapper = mapper;
        }

        //3
       // private readonly ClientService _clientService;
        public List<ClientDTO> Get()
        {
            var clients = _dataContext.clientList.ToList();
            return _mapper.Map<List<ClientDTO>>(clients);
        }

        //4
        public ClientDTO Get(int id)
        {
            var client1 = _dataContext.clientList.FirstOrDefault(t => t.Id == id);
            if (client1 == null)
            {
                return null;
            }
          
            return _mapper.Map<ClientDTO>(client1);     
        }


        public void Post(Client c)
        {
            _dataContext.clientList.Add(c);
            _dataContext.SaveChanges();
        }


        public void UpdateClient(Client updatedClient)
        {
            Client existingClient = _dataContext.clientList.FirstOrDefault(c1 => c1.Id == updatedClient.Id);
            if (existingClient != null)
            {
                existingClient.Id = updatedClient.Id;
                existingClient.Name = updatedClient.Name;
                existingClient.PhoneNumber = updatedClient.PhoneNumber;
                existingClient.LicenseNumber = updatedClient.LicenseNumber;
                existingClient.Address = updatedClient.Address;
                existingClient.Email = updatedClient.Email;
                existingClient.DateOfBirth = updatedClient.DateOfBirth;
            }
            else
            {
                throw new Exception("Client not found");
            }
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var clientToDelete = _dataContext.clientList.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                _dataContext.clientList.Remove(clientToDelete);
            }
            _dataContext.SaveChanges();
        }
    }
}
