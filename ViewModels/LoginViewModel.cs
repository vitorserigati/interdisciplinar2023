using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Interdisciplinar2023.ViewModels;

public class LoginViewModel
{
    [DisplayName("E-mail")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Por favor. Digite um e-mail Válido")]
    public string Email { get; set; }


    [DisplayName("Senha")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Por favor. Digite uma senha!")]
    public string Password { get; set; }
}
