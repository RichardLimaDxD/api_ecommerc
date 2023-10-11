using AutoMapper;
using Ecom.Core.Dtos;
using Ecom.Core.Entities;
using Ecom.Core.Entities.Orders;


namespace API.MappingProfiles {
    public class MappingUser : Profile {
        public MappingUser() {
            CreateMap<Address, AddressDto>().ReverseMap();

        }
    }
}
