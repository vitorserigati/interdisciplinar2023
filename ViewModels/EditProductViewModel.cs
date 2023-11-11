using System.ComponentModel.DataAnnotations;
using Interdisciplinar2023.Data.Enum;
namespace Interdisciplinar2023.ViewModels;

public class EditProductViewModel
{
    public Guid Id { get; set; }

    [Required]
    [Display(Name = "Nome")]
    public string? Name { get; set; }

    [Required]
    [Display(Name = "Preço")]
    public decimal Value { get; set; }

    [Required]
    [Display(Name = "Corredor")]
    public string? Corridor { get; set; }

    [Required]
    [Display(Name = "Prateleira")]
    public string? Shelf { get; set; }

    [Required]
    [Display(Name = "Lote")]
    public string? Batch { get; set; }

    [Required]
    [Display(Name = "Validade")]
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy, HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime Validity { get; set; }

    [Required]
    [Display(Name = "Categoria")]
    public ProductCategory Category { get; set; }

    [Required]
    [Display(Name = "Descrição")]
    public string? Description { get; set; }

    [Required]
    [Display(Name = "Quantidade")]
    public int Quantity { get; set; }

}
