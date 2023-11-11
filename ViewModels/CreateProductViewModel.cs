using System.ComponentModel;
using Interdisciplinar2023.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Interdisciplinar2023.ViewModels;

public class CreateProductViewModel
{
    [DisplayName("Nome")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? Name { get; set; }

    [DisplayName("Preço")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public decimal Value { get; set; }

    [DisplayName("Corredor")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? Corridor { get; set; }

    [DisplayName("Prateleira")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? Shelf { get; set; }

    [DisplayName("Lote")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? Batch { get; set; }

    [DisplayName("Validade")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy, HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime Validity { get; set; } = DateTime.UtcNow;

    [DisplayName("Categoria")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public ProductCategory Category { get; set; }

    [DisplayName("Descrição")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string? Description { get; set; }

    [DisplayName("Quantidade")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public int Quantity { get; set; }

    [DisplayName("Fornecedor")]
    public Provider? Provider { get; set; }

    [Required]
    public Guid ProviderId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public IEnumerable<Provider?> ProviderList { get; set; }

}
