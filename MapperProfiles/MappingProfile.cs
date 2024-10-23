using AutoMapper;
using ecommerceAPI.DTO.Order.Response;
using ecommerceAPI.Model;

namespace ecommerceAPI.MapperProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            orderMapping();
        }

        public void orderMapping()
        {
            CreateMap<OrderItems, OrderItemResponseDTO>().ForMember(dest => dest.PriceEach, opt => opt.MapFrom(src => src.Price));
        }
    }
}
