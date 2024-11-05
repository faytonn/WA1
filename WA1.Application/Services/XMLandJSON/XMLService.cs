using System.Xml.Serialization;
using WA1.Domain.Entities;

namespace WA1.Application.Services.XMLandJSON
{
    public class XMLService
    {
        private readonly string _filePath;

        public XMLService(string filePath)
        {
            _filePath = filePath;
        }


        public void SaveToXml(List<Person> people)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Person>));
            using (var sw = new FileStream(_filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(sw, people);
            }
        }
        public List<Person> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Person>();
            }

            var xmlSerializer = new XmlSerializer(typeof(List<Person>));
            using (var sr = new StreamReader(_filePath))
            {
                return (List<Person>)xmlSerializer.Deserialize(sr);
            }
        }
    }
}
