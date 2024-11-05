using System.Text.Json;
using WA1.Application.Services.PersonService;
using WA1.Domain.Entities;

namespace WA1.Application.Services.XMLandJSON
{
    public class JsonService : IPersonService
    {
        private readonly string _filePath;

        public JsonService(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<List<Person>> GetAllPeopleAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Person>();
            }

            var data = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Person>>(data) ?? new List<Person>();
        }


        public async Task SaveToFileAsync(List<Person> people)
        {
            var data = JsonSerializer.Serialize(people, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(_filePath,data);
        }

        public async Task<Person?> GetbyId(int id)
        {
            var people = await GetAllPeopleAsync();
            return people.FirstOrDefault(x => x.Id == id);  
        }

        public async Task AddAsync(Person person)
        {
            var people = await GetAllPeopleAsync();
            people.Add(person);
            await SaveToFileAsync(people);
        }

        public async Task UpdateAsync(int id, Person person)
        {
            var people = await GetAllPeopleAsync();
            var index = people.FindIndex(p => p.Id == person.Id);
            if (index != -1)
            {
                people[index] = person;
                await SaveToFileAsync(people);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var people = await GetAllPeopleAsync();
            var person = people.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                people.Remove(person);
                await SaveToFileAsync(people);
            }
        }

       
    }
}
