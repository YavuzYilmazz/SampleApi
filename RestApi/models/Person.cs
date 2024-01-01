// Models/Person.cs

using System.ComponentModel.DataAnnotations;

public class Person
{
    public int Id { get; set; }

    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; } = string.Empty;
}
