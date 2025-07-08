using Application.DTOs.Purchase;
using AutoMapper;
using Domain.entities;


namespace Application.Mapper.PurchasesHistoryProfile
{
    internal class PurchaseHisMapping:Profile
    {
        public void ApplyMapping()
        {
            CreateMap<PurchaseHistory, PurchasHistoryDto>();

        }
    }
}
