using Domain.entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PurchasHistoryService
    {
        private readonly IUnitOfWork _unitOfwork;

        public PurchasHistoryService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public void Add(PurchaseHistory purchase)
        {

            if (purchase != null)
            {
                _unitOfwork.PurchasesHistory.AddAsync(purchase);
                _unitOfwork.SaveAsync();

            }
        }

        public void Delete(int ID)
        {
            var PurchaseHistory = GetByID(ID);
            if (PurchaseHistory != null)
            {
                _unitOfwork.PurchasesHistory.DeleteAsync(ID);
                _unitOfwork.SaveAsync();
            }

        }

        public PurchaseHistory? GetByID(int id)
        {
            var PurchaseHistory = _unitOfwork.PurchasesHistory.GetByIDAsync(id);
            if (PurchaseHistory != null)
            {
                return PurchaseHistory.Result;
            }
            return null;
            //
        }

        public IEnumerable<PurchaseHistory> Gettall()
        {
            var PurchasesHistory = _unitOfwork.PurchasesHistory.GetAllAsync().Result;

            return PurchasesHistory;
            // 
        }

        public void Update(PurchaseHistory purchase)
        {


            if (GetByID(purchase.Id) != null)
            {
                _unitOfwork.PurchasesHistory.UpdateAsync(purchase);
                _unitOfwork.SaveAsync();

            }
        }


    }
}
