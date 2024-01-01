using System.Collections.Generic;

public interface IPersonService
{
    List<Person> GetPersons();
    Person GetPersonById(int id);
    void AddPerson(Person person);
    void UpdatePerson(int id, Person updatedPerson);
    void DeletePerson(int id);
}
