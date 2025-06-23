using Domain.entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PersonService 
    {
        private readonly IUnitOfWork _unitOfwork;

        public PersonService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public void Add(Person person)
        {

            if (person != null)
            {
                _unitOfwork.People.AddAsync(person);
                _unitOfwork.SaveAsync();

            }
        }

        public void Delete(int ID)
        {
            var Person = GetByID(ID);
            if (Person != null)
            {
                _unitOfwork.People.DeleteAsync(ID);
                _unitOfwork.SaveAsync();
            }

        }

        public Person? GetByID(int id)
        {
            var person = _unitOfwork.People.GetByIDAsync(id);
            if (person != null)
            {
                return person.Result;
            }
            return null;
            //
        }

        public IEnumerable<Person> Gettall()
        {
            var People = _unitOfwork.People.GetAllAsync().Result;

            return People;
            // 
        }

        public void Update(Person person)
        {


            if (GetByID(person.Id) != null)
            {
                _unitOfwork.People.UpdateAsync(person);
                _unitOfwork.SaveAsync();

            }
        }


    }
}
