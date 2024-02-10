using AutoMapper;
using Customer.DTOs.AppDTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infrastructure.MappingProfile
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerCreateDTO, Customer.Core.DomainModels.Customer>().ReverseMap();
            CreateMap<CustomerListingDTO, Customer.Core.DomainModels.Customer>().ReverseMap();
            CreateMap<CustomerUpdateDTO, Customer.Core.DomainModels.Customer>().ReverseMap();
        }
    }
}