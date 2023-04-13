using AutoMapper;
using Domain.Entities;
using Models.DTOs.Output;

namespace Services.Mappers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerSocialNetworksDTO>();

            CreateMap<SocialNetwork, SocialNetworkDTO>();
        }
    }
}