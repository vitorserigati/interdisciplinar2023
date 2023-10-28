
using System.ComponentModel.DataAnnotations;
using Interdisciplinar2023.Models;
using Interdisciplinar2023.Data.Enum;
namespace Interdisciplinar2023.ViewModels;

public class EditViewModel
{

    [Required]
    public string? Name { get; set; }

    [Required]
    public decimal Value { get; set; }

    [Required]
    public string? Corridor { get; set; }

    [Required]
    public string? Shelf { get; set; }

    [Required]
    public string? Batch { get; set; }

    [Required]
    
    public DateTime Validity { get; set; } = DateTime.UtcNow;

    [Required]
    public ProductCategory Category { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public int Quantity { get; set; }

}
