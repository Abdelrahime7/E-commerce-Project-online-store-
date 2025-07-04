using Domain.entities;
using Infrastructure.ADbContext;
using Application.Interface;
using Domain.Interfaces.Generic;

namespace Infrastructure.Repository.GenericRepo
{
    public class UnitOFwork : IUnitOfWork
    {

        private readonly AppDbContext _appDbContext;

        public UnitOFwork(AppDbContext appDbContext)
        { 

        }



        public async Task SaveAsync() => await _appDbContext.SaveChangesAsync();

        public void Dispose()=>_appDbContext.Dispose();

        
    }
}
