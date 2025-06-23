
using Domain.entities;
using Domain.Interfaces;

namespace OnlineStorAccess.Services
{
    public  class ReviewService
    {
        private readonly IUnitOfWork _unitOfwork;

        public ReviewService( IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public void Add(Review review)
        {
            if (review != null)
            {
                _unitOfwork.Reviews.AddAsync(review);
                _unitOfwork.SaveAsync();

            }
        }

        public void Delete(int ID)
        {
            var review = GetByID(ID);
            if (review != null)
            {
                _unitOfwork.Reviews.DeleteAsync(ID);
                _unitOfwork.SaveAsync();
            }
        }

        public Review ?GetByID(int id)
        {
            var review = _unitOfwork.Reviews.GetByIDAsync(id);
            if (review != null)
            {
                return review.Result;
            }
            return null;
        }

        public IEnumerable<Review> Gettall()
        {
           var Reviews = _unitOfwork.Reviews.GetAllAsync().Result;
            return Reviews;
        }

        public void Update(Review review)
        {
            if (GetByID(review.Id) != null)
            {
                _unitOfwork.Reviews.UpdateAsync(review);
                _unitOfwork.SaveAsync();

            }
        }
    }
}
