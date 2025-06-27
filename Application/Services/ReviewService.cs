
using Domain.entities;
using Domain.Interfaces.Generic;
using System.Threading.Tasks;

namespace OnlineStorAccess.Services
{
    public  class ReviewService
    {
        private readonly IUnitOfWork _unitOfwork;

        public ReviewService( IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task<int> AddAsync(Review review)
        {
            if (review != null)
            {
              await  _unitOfwork.Reviews.AddAsync(review);
               return review.Id;
            }
            return 0;
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            var review = GetByIDAsync(ID);
            if (review != null)
            {
               await _unitOfwork.Reviews.DeleteAsync(ID);
                return true;
            }
            return false;
        }

        public async Task<Review ?> GetByIDAsync(int id)
        {
            var review = await _unitOfwork.Reviews.GetByIDAsync(id);
            if (review != null)
            {
                return review;
            }
            return null;
        }

        public async Task<IEnumerable<Review>> GettallAsync()
        {
            var Reviews = await _unitOfwork.Reviews.GetAllAsync();
                 
            return Reviews;
        }

        public async Task UpdateAsync(Review review)
        {
           
               await _unitOfwork.Reviews.UpdateAsync(review);
              
            
        }
    }
}
