using Domain.entities;
using Domain.Interfaces.Generic;
using System.Threading.Tasks;


namespace Application.Services
{
    public class SalesService 
    {

        readonly private IUnitOfWork _unitOfwork;

        public SalesService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public async Task <int>AddAsync(Sale sale)
        {
            if (sale != null)
            {
                
               await _unitOfwork.Salles.AddAsync(sale);
              return sale.Id;

            }
            return 0;
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            var saleProcess = await GetByIDAsync(ID);
            if (saleProcess != null)
            {
               await _unitOfwork.Salles.DeleteAsync(ID);
                return true;
            }
            return false;
        }

        public async Task<Sale?> GetByIDAsync(int id)
        {
            var saleProcess =await _unitOfwork.Salles.GetByIDAsync(id);
            if (saleProcess != null)
            {
                return saleProcess;
            }
            return null;
        }

        public async Task<IEnumerable<Sale>> GettallAsync()
        {

            var Salles = await _unitOfwork.Salles.GetAllAsync();

            return Salles;
        }

        public async Task UpdateAsync(Sale sale)
        {
           
               await _unitOfwork.Salles.UpdateAsync(sale);
            
        }
    }
}
     