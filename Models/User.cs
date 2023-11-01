using Microsoft.AspNetCore.Identity;
namespace Interdisciplinar2023.Models;

public class User : IdentityUser<Guid>
{
    public string Celphone { get; set; }

    public string Phone { get; set; }

}
