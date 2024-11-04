using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WA1.Domain.Entities;

namespace WA1.Application.Services.PersonService
{
    public interface IPersonService
    {
        List<Person> GetAllPeople();
        Task<Person?> GetbyId(int id);
        Task<Person> AddAsync(Person person); 
        Task<Person> UpdateAsync(Person person);
        Task<Person> DeleteAsync(int id);

    }
}
