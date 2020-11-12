using AutoMapper;
using EqAssign.Dtos;
using EqAssign.DTOs;
using EqAssign.Models;

namespace EqAssign.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Equipment, EquipmentDto>();
            Mapper.CreateMap<MembershipType, MembershiptTypeDto>();
            Mapper.CreateMap<ModelType, ModelsDto>();
            Mapper.CreateMap<Rental, NewRentalDto>();
            Mapper.CreateMap<Invoice, InvoiceDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<EquipmentDto, Equipment>()
                .ForMember(e => e.Id, opt => opt.Ignore());

        }
    }
}