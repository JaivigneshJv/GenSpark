using AutoMapper;
using PizzaOrderingAPI.Models;
using PizzaOrderingAPI.Models.DTOs;

namespace PizzaOrderingAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User mappings
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserRegisterDto>().ReverseMap();

            // Pizza mappings
            CreateMap<Pizza, PizzaDto>().ReverseMap();

            // Order mappings
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
