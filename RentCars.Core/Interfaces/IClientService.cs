﻿using RentCars.Core.DTOs;
using RentCars.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Core.Interfaces
{
    public interface IClientService
    {
        public List<ClientDTO> Get();
        public ClientDTO Get(int id);
        public void Post(Client c);
        public void UpdateClient(Client updatedClient);
        public void Delete(int id);
    }
}
