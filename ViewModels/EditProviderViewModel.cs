using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Interdisciplinar2023.ViewModels;

public class EditProviderViewModel
{
    public Guid Id { get; set; }

    [DisplayName("Razão Social")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string CorporateName { get; set; } = string.Empty;

    [DisplayName("CNPJ")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Document { get; set; } = string.Empty;

    [DisplayName("Rua")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Street { get; set; } = string.Empty;

    [DisplayName("Bairro")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Neighborhood { get; set; } = string.Empty;

    [DisplayName("Cidade")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string City { get; set; } = string.Empty;

    [DisplayName("Estado")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string State { get; set; } = string.Empty;

    [DisplayName("Cep")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string PostalCode { get; set; } = string.Empty;

    [DisplayName("E-mail")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Email { get; set; } = string.Empty;

    [DisplayName("Telefone")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Phone { get; set; } = string.Empty;

    [DisplayName("Celular")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Celphone { get; set; } = string.Empty;
}
