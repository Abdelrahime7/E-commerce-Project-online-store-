using Domain.entities;
using Domain.Interfaces;

namespace OnlineStorAccess.Services
{
    public class InvoicesServices 
    {

        private readonly IUnitOfWork _unitOfwork;
        public InvoicesServices(IUnitOfWork unitOfwork)
        {
         _unitOfwork = unitOfwork;    
        }

        public  async Task<int> AddAsync(Invoice invoice)
        {
            if (invoice != null)
            {
              await  _unitOfwork.Invoices.AddAsync(invoice);
                return invoice.Id;
            }
            return 0;
        }

        public async Task< bool> DeleteAsync(int ID)
        {

            if (ID >0)
            {
               await _unitOfwork.Invoices.DeleteAsync(ID);
                return true;
            }
            return false;
                
        }

        public async Task< Invoice ? > GetByIDAsync(int id)
        {
            var Invoice =await _unitOfwork.Invoices.GetByIDAsync(id);
            if (Invoice != null)
            {
                return Invoice;
            }
            return null;
        }

        public async Task < IEnumerable<Invoice>> GettallAsync()
        {
            var Invoices = await _unitOfwork.Invoices.GetAllAsync();

            return Invoices;
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            if (await GetByIDAsync(invoice.Id) != null)
            {
               await _unitOfwork.Invoices.UpdateAsync(invoice);


            }
        }
    }
}
