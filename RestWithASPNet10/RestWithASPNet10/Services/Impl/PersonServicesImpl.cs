using RestWithASPNet10.Model;

namespace RestWithASPNet10.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {
        public Person Create(Person person)
        {
            person.Id = new Random().Next(1, 10000);
            return person;
        }

        public void Delete(long id)
        {
            // Simulate deletion logic here
        }

        public List<Person> FindAll()
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                var person = MockPerson(i);
                people.Add(person);
            }

            return people; 
        }

        public Person FindById(long id)
        {
            var person = MockPerson((int) id);

            return person;
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            var person = new Person
            {
                Id = new Random().Next(1, 1000),
                FirstName = "John " + i,
                LastName = "Doe " + i,
                Address = "123 Main " + i,
                Gender = "Male"
            };

            return person;
        }
    }
}
