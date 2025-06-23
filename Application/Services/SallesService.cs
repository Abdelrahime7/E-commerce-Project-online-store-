using Domain.entities;
using Domain.Interfaces;


namespace Application.Services
{
    public class SalesService 
    {

        readonly private IUnitOfWork _unitOfwork;

        public SalesService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public void Add(Sales sale)
        {
            if (sale != null)
            {
                _unitOfwork.Salles.AddAsync(sale);
                _unitOfwork.SaveAsync();

            }
        }

        public void Delete(int ID)
        {
            var saleProcess = GetByID(ID);
            if (saleProcess != null)
            {
                _unitOfwork.Salles.DeleteAsync(ID);
                _unitOfwork.SaveAsync();
            }
        }

        public Sales? GetByID(int id)
        {
            var saleProcess = _unitOfwork.Salles.GetByIDAsync(id);
            if (saleProcess != null)
            {
                return saleProcess.Result;
            }
            return null;
        }

        public IEnumerable<Sales> Gettall()
        {

            var Salles = _unitOfwork.Salles.GetAllAsync().Result;

            return Salles;
        }

        public void Update(Sales sale)
        {
            if (GetByID(sale.Id) != null)
            {
                _unitOfwork.Salles.UpdateAsync(sale);
                _unitOfwork.SaveAsync();

            }
        }
    }
}
