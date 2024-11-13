using Microsoft.AspNetCore.Mvc;
using RentCars.Controllers;
using RentCars.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace UnitTest
{
    public class UnitTestClient
    {
        public ClientController clientTest;
        public UnitTestClient()
        {
            // מוודא שהרשימה תיווצר על ידי המחלקה הקיימת
            clientTest = new ClientController();
        }
        [Fact]
        public void Get_ReturnsAllClients()
        {
            var result = clientTest.Get();
            Assert.Equal(DataContext.clientList.Count, result.Count());
        }
        [Fact]
        public void GetById_ReturnsClient_WhenClientExists()
        {
            var client1 = DataContext.clientList.FirstOrDefault();
            if (client1 != null)
            {
                var result = clientTest.Get(client1.Id);
                Assert.Equal("value", result);
            }
        }
        [Fact]
        public void GetById_ReturnsNotFound_WhenClientDoesNotExist()
        {
            var result = clientTest.Get(99);
            Assert.Equal("User not found", result);
        }
        [Fact]
        public void Post_AddsClientToList()
        {
            var newClient = new Client(3, "New Client", "123456789", 1234);
            clientTest.Post(newClient); 
            Assert.Contains(newClient, DataContext.clientList);
        }
        [Fact]
        public void Put_UpdatesClientInList()
        {
            var existingClient = DataContext.clientList.FirstOrDefault();
            if (existingClient != null)
            {
                var updatedClient = new Client(existingClient.Id, "Updated Client", "987654321", 5678);
                clientTest.Put(existingClient.Id, updatedClient);
                var client = DataContext.clientList.First(c => c.Id == existingClient.Id);
                Assert.Equal("Updated Client", client.Name);//בדיקה אם הלקוח עודכן
                Assert.Equal("987654321", client.PhoneNumber);
                Assert.Equal(5678, client.LicenseNumber);
            }
        }
        [Fact]
        public void Delete_RemovesClientFromList()
        {
            var clientToDelete = DataContext.clientList.FirstOrDefault();
            if (clientToDelete != null)
            {
                clientTest.Delete(clientToDelete);
                Assert.DoesNotContain(clientToDelete, DataContext.clientList);
            }
        }
    }
}