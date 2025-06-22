using Domain.entities;
using OnlineStorAccess.DataAccessCls;


namespace Application.Services
{
    public class SallesService 
    {

        readonly private IUnitOfwork _unitOfwork;

        public SallesService(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public void Add(Salle sale)
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

        public Salle? GetByID(int id)
        {
            var saleProcess = _unitOfwork.Salles.GetByIDAsync(id);
            if (saleProcess != null)
            {
                return saleProcess.Result;
            }
            return null;
        }

        public IEnumerable<Salle> Gettall()
        {

            var Salles = _unitOfwork.Salles.GetAllAsync().Result;

            return Salles;
        }

        public void Update(Salle sale)
        {
            if (GetByID(sale.ID) != null)
            {
                _unitOfwork.Salles.UpdateAsync(sale);
                _unitOfwork.SaveAsync();

            }
        }
    }
}
