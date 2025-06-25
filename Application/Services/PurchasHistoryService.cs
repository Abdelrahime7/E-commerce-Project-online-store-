using Domain.entities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PurchasHistoryService
    {
        private readonly IUnitOfWork _unitOfwork;

        public PurchasHistoryService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task<int> AddAsync(PurchaseHistory purchase)
        {

            if (purchase != null)
            {
             await   _unitOfwork.PurchasesHistory.AddAsync(purchase);
                return purchase.Id;

            }
            return 0;
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            if (ID >0)
            {
               await _unitOfwork.PurchasesHistory.DeleteAsync(ID);
                return true;
            }
            return false;
        }

        public async Task<PurchaseHistory?> GetByIDAsync(int id)
        {
            var PurchaseHistory =await _unitOfwork.PurchasesHistory.GetByIDAsync(id);
            if (PurchaseHistory != null)
            {
                return PurchaseHistory;
            }
            return null;
            //
        }

        public async Task<IEnumerable<PurchaseHistory>> GettallAsync()
        {
            var PurchasesHistory = await _unitOfwork.PurchasesHistory.GetAllAsync();

            return PurchasesHistory;
            // 
        }

        public async Task UpdateAsync(PurchaseHistory purchase)
        {


          
             await _unitOfwork.PurchasesHistory.UpdateAsync(purchase);
          
        }


    }
}
