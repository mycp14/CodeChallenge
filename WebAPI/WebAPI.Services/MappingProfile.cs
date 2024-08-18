using AutoMapper;
using System.Xml.Schema;
using WebAPI.EFCore;

namespace WebAPI.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PizzaType, PizzaTypeVM>().ReverseMap();
            CreateMap<Pizza, PizzaVM>()
                .ForMember(x => x.PizzaType, opt => opt.MapFrom(x => x.PizzaType))
                .ReverseMap();
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailVM>()
                .ForMember(x => x.Order, opt => opt.MapFrom(x => x.Order))
                .ForMember(x => x.Pizza, opt => opt.MapFrom(x => x.Pizza))
                .ReverseMap();
        }
    }
}