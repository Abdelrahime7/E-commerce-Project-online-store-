using Application.Interface;
using Domain.entities;
using Infrastructure.ADbContext;
using Infrastructure.Repository.GenericRepo;

namespace Infrastructure.Repository.specific_Repo
{
    public class PersonRepository(AppDbContext context) : GenericRepository<Person>(context),IPersonRepository
    {


    }
   
}
