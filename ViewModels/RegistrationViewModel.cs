using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Interdisciplinar2023.ViewModels;

public class RegistrationViewModel
{
    [DisplayName("E-Mail")]
    [Required(ErrorMessage = "Por favor, digite um e-mail válido!")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }


    [DisplayName("Senha")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Por favor. Digite uma senha!")]
    public string Password { get; set; }


    [DataType(DataType.Password)]
    [DisplayName("Confirme sua Senha")]
    [Required(ErrorMessage = "Por favor. Digite uma senha!")]
    [Compare("Password", ErrorMessage = "A senha e a confirmação de senha são diferentes")]
    public string ConfirmPassword { get; set; }

    [DisplayName("Celular")]
    [Required(ErrorMessage = "Por favor, digite um número de celular válido")]
    public string Celphone { get; set; }

    [DisplayName("Telefone")]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Digite um número de telefone")]
    public string Phone { get; set; }
}
