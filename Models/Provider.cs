using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Interdisciplinar2023.Models
{
    public class Provider
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("CNPJ")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Document { get; set; }


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

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
