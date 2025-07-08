using Application.DTOs.Customer;
using AutoMapper;
using Domain.entities;


namespace Application.Mapper.InvoicesProfile
{
    internal class InvoiceMapping: Profile
    {
        public void ApplyMapping()
        {
            CreateMap<Customer, CustomerDto>();

        }
    }
}
