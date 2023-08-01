using AutoMapper;
using TMS.API.Models;
using TMS.API.Models.Dto;

namespace TMS.API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.CustomerName)).ReverseMap();
        }
    }
}
