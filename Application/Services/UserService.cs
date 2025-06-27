using Domain.entities;
using Domain.Interfaces.Generic;
using System.Threading.Tasks;

namespace OnlineStorAccess.Services
{
    public  class UserService
    {
        readonly private IUnitOfWork _unitOfwork;
        public UserService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task <int> AddAsync(User user)
        {
            if (user != null)
            {
                await _unitOfwork.Users.AddAsync(user);
                return user.Id;
            }
            return 0;
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            var user = GetByIDAsync(ID);
            if (user != null)
            {
              await  _unitOfwork.Users.DeleteAsync(ID);
                return true;
            }
            return false;   
        }

        public async Task<User?> GetByIDAsync(int id)
        {
            var user = await _unitOfwork.Users.GetByIDAsync(id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<IEnumerable<User>> GettallAsync()
        {
            var Users = await _unitOfwork.Users.GetAllAsync();

            return Users;
        }

        public async Task UpdateAsync(User user)
        {
           
            
              await  _unitOfwork.Users.UpdateAsync(user);
              
            
        }
    }
}
