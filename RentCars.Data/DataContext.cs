using System.Net;
using System.Security.Claims;
using System;
using RentCars.Core.Interfaces;
using RentCars.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RentCars.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Car> carList { get; set; }
        public DbSet<Client> clientList { get; set; }
        public DbSet<Orders> orderList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=(localdb)\ProjectModels;Database=Data_db")
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
      

    }
}
