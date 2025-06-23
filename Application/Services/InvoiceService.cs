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
        public void Add(Invoice invoice)
        {
            if (invoice != null)
            {
                _unitOfwork.Invoices.AddAsync(invoice);
                _unitOfwork.SaveAsync();
            }
        }

        public void Delete(int ID)
        {
            var invoice = GetByID(ID);
            if (invoice != null)
            {
                _unitOfwork.Invoices.DeleteAsync(ID);
                _unitOfwork.SaveAsync();
            }
        }

        public Invoice ? GetByID(int id)
        {
            var Invoice = _unitOfwork.Invoices.GetByIDAsync(id);
            if (Invoice != null)
            {
                return Invoice.Result;
            }
            return null;
        }

        public IEnumerable<Invoice> Gettall()
        {
            var Invoices = _unitOfwork.Invoices.GetAllAsync().Result;

            return Invoices;
        }

        public void Update(Invoice invoice)
        {
            if (GetByID(invoice.Id) != null)
            {
                _unitOfwork.Invoices.UpdateAsync(invoice);
                _unitOfwork.SaveAsync();

            }
        }
    }
}
