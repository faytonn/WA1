using System.Xml.Serialization;
using WA1.Application.Services.PersonService;
using WA1.Domain.Entities;

namespace WA1.Application.Services.XMLandJSON
{
    public class XMLService : IPersonService
    {
        private readonly string _filePath;

        public XMLService(string filePath)
        {
            _filePath = filePath;
        }


        public async Task SaveToXmlAsync(List<Person> people)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Person>));
            using (var fs = new FileStream(_filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, people);
                await fs.FlushAsync();
            }
        }
        public async Task<List<Person>> GetAllPeopleAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Person>();
            }

            var xmlSerializer = new XmlSerializer(typeof(List<Person>));
            using (var fs = new FileStream(_filePath, FileMode.Open))
            {
                return (List<Person>)(xmlSerializer.Deserialize(fs) ?? new List<Person>());
            }
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
            SaveToXmlAsync(people);
        }

        public async Task UpdateAsync(int id, Person person)
        {
            var people = await GetAllPeopleAsync();
            var index = people.FindIndex(p => p.Id == id);
            if (index != -1)
            {
                people[index] = person;
                SaveToXmlAsync(people);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var people = await GetAllPeopleAsync();
            var person = people.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                people.Remove(person);
                SaveToXmlAsync(people);
            }
        }

}
    
}
