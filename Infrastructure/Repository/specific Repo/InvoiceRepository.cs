using Application.Interface;
using Domain.entities;
using Infrastructure.ADbContext;
using Infrastructure.Repository.GenericRepo;

namespace Infrastructure.Repository.specific_Repo
{
    public class InvoiceRepository(AppDbContext context) : GenericRepository<Invoice>(context),IInvoiceRepository
    {


    }
   
}
