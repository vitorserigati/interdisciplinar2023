using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Interdisciplinar2023.Data.Enum;

namespace Interdisciplinar2023.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

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
        public DateTime Validity { get; set; } = DateTime.Now;

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public ProductCategory Category { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Description { get; set; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Quantity { get; set; }

        public Provider? Provider { get; set; }

        [DisplayName("Fornecedor")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public Guid ProviderId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
