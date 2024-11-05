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
        Task<Person?> GetbyId(int id);
        Task AddAsync(Person person); 
        Task UpdateAsync(int id, Person person);
        Task DeleteAsync(int id);
        Task<List<Person>> GetAllPeopleAsync();

    }
}
