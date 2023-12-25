// Models/Person.cs

using System.ComponentModel.DataAnnotations;

public class Person
{
    public int Id { get; set; }

    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; }
}
