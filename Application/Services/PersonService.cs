using Domain.entities;
using Domain.Interfaces.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonService 
    {
        private readonly IUnitOfWork _unitOfwork;

        public PersonService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task<int> AddAsync(Person person)
        {

            if (person != null)
            {
              await  _unitOfwork.People.AddAsync(person);
                
                return  person.Id ;
            }
            else return 0;

        }

        public async Task<bool> DeleteAsync(int ID)
        {
            var Person =  await GetByIDAsync(ID);
            if (Person != null)
            {
               await _unitOfwork.People.DeleteAsync(ID);
                return true;
            }

            return false;
        }

        public async Task<Person?> GetByIDAsync(int id)
        {
            var person = await _unitOfwork.People.GetByIDAsync(id);
            if (person != null)
            {
                return person;
            }
            return null;
            //
        }

        public async Task<IEnumerable<Person>> GettallAsync()
        {
            var People = await _unitOfwork.People.GetAllAsync();
            return People;
            // 
        }

        public async Task UpdateAsync(Person person)
        {

        await  _unitOfwork.People.UpdateAsync(person);
               
        }


    }
}
