using AutoMapper;
using CarSalesSystem.Dtos;
using CarSalesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesSystem.Profiles
{
    public class CarProfile : Profile  
    {
        public CarProfile()
        {
            //source -> target
            CreateMap<Car, CarReadDto>();
            CreateMap<CarCreateDto, Car>();
        }
    }
}
