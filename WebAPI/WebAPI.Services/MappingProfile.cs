﻿using AutoMapper;
using WebAPI.EFCore;

namespace WebAPI.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PizzaType, PizzaTypeVM>().ReverseMap();
            CreateMap<Pizza, PizzaVM>().ReverseMap();
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailVM>().ReverseMap();
        }
    }
}