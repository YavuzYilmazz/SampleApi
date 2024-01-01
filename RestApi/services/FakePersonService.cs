using System.Collections.Generic;
using System.Linq;


public class FakePersonService : IPersonService
{
    private List<Person> persons;

    public FakePersonService()
    {
        persons = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe" },
            new Person { Id = 2, FirstName = "Jane", LastName = "Smith" },
            new Person { Id = 3, FirstName = "Alice", LastName = "Johnson" },
            new Person { Id = 4, FirstName = "Bob", LastName = "Williams" },
            new Person { Id = 5, FirstName = "Eva", LastName = "Miller" }
        };
    }

    public List<Person> GetPersons()
    {
        return persons;
    }

    public Person GetPersonById(int id)
    {
        return persons.FirstOrDefault(p => p.Id == id);
    }

    public void AddPerson(Person person)
    {
        person.Id = persons.Count + 1;
        persons.Add(person);
    }

    public void UpdatePerson(int id, Person updatedPerson)
    {
        var existingPerson = persons.FirstOrDefault(p => p.Id == id);
        if (existingPerson != null)
        {
            existingPerson.FirstName = updatedPerson.FirstName;
            existingPerson.LastName = updatedPerson.LastName;
        }
    }

    public void DeletePerson(int id)
    {
        var person = persons.FirstOrDefault(p => p.Id == id);
        if (person != null)
        {
            persons.Remove(person);
        }
    }
}
