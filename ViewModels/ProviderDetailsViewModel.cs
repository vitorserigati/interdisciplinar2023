using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Interdisciplinar2023.Models;

namespace Interdisciplinar2023.ViewModels;

public class ProviderDetailsViewModel
{
    [Required]
    public Guid Id { get; set; }

    [DisplayName("Razão Social")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? CorporateName { get; set; }

    [DisplayName("Rua")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? Street { get; set; }

    [DisplayName("Bairro")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? Neighborhood { get; set; }

    [DisplayName("Cidade")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? City { get; set; }

    [DisplayName("Estado")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? State { get; set; }

    [DisplayName("Cep")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? PostalCode { get; set; }

    [DisplayName("E-mail")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? Email { get; set; }

    [DisplayName("Telefone")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? Phone { get; set; }

    [DisplayName("Celular")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? Celphone { get; set; }

    [DisplayName("Produtos Vinculados")]
    public IEnumerable<Product?> Products { get; set; }
}
