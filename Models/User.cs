using System.ComponentModel.DataAnnotations;
namespace Interdisciplinar2023.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } = new Guid();

    public string? Email { get; set; }

    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }

}
