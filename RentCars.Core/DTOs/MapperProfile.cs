using AutoMapper;
using RentCars.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCars.Core.DTOs
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
           CreateMap<Orders, OrdersDTO>().ReverseMap();
        }
        
    }
}
