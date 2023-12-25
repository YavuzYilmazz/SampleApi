using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private static List<Person> persons = new List<Person>
{
    new Person { Id = 1, FirstName = "John", LastName = "Doe" },
    new Person { Id = 2, FirstName = "Jane", LastName = "Smith" },
    new Person { Id = 3, FirstName = "Alice", LastName = "Johnson" },
    new Person { Id = 4, FirstName = "Bob", LastName = "Williams" },
    new Person { Id = 5, FirstName = "Eva", LastName = "Miller" }
};

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(persons);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var person = persons.FirstOrDefault(p => p.Id == id);

        if (person == null)
            return NotFound();

        return Ok(person);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Person person)
    {
        if (person == null)
            return BadRequest();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        person.Id = persons.Count + 1;
        persons.Add(person);

        return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Person updatedPerson)
    {
        var existingPerson = persons.FirstOrDefault(p => p.Id == id);

        if (existingPerson == null)
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        existingPerson.FirstName = updatedPerson.FirstName;
        existingPerson.LastName = updatedPerson.LastName;

        return Ok(existingPerson);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var person = persons.FirstOrDefault(p => p.Id == id);

        if (person == null)
            return NotFound();

        persons.Remove(person);

        return NoContent();
    }
}