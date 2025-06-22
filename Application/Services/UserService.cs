using OnlineStorAccess.DataAccessCls;
using OnlineStorAccess.entities;

namespace OnlineStorAccess.Services
{
    public  class UserService
    {
        readonly private IUnitOfwork _unitOfwork;
        public UserService(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public void Add(User user)
        {
            if (user != null)
            {
                _unitOfwork.Users.AddAsync(user);
                _unitOfwork.SaveAsync();

            }
        }

        public void Delete(int ID)
        {
            var user = GetByID(ID);
            if (user != null)
            {
                _unitOfwork.Users.DeleteAsync(ID);
                _unitOfwork.SaveAsync();
            }
        }

        public User? GetByID(int id)
        {
            var user = _unitOfwork.Users.GetByIDAsync(id);
            if (user != null)
            {
                return user.Result;
            }
            return null;
        }

        public IEnumerable<User> Gettall()
        {
            var Users = _unitOfwork.Users.GetAllAsync().Result;

            return Users;
        }

        public void Update(User user)
        {
            if (GetByID(user.Id) != null)
            {
                _unitOfwork.Users.UpdateAsync(user);
                _unitOfwork.SaveAsync();

            }
        }
    }
}
