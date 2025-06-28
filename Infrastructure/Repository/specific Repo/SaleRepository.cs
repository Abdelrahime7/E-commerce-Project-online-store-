using Application.Interface;
using Domain.entities;
using Infrastructure.ADbContext;
using Infrastructure.Repository.GenericRepo;

namespace Infrastructure.Repository.specific_Repo
{
    public class SaleRepository(AppDbContext context) : GenericRepository<Sale>(context),ISaleRepository
    {


    }
   
}
