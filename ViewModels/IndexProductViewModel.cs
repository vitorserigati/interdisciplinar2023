using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Interdisciplinar2023.Data.Enum;

namespace Interdisciplinar2023.Models
{
    public class IndexProductViewModel
    {

        public IEnumerable<Product> Products { get; set; }

        [DisplayName("Selecione um Fornecedor")]
        public Guid SelectedProviderId { get; set; }

        public IEnumerable<Provider> Providers { get; set; }

        [Display(Name = "Selecione uma Categoria")]
        public ProductCategory SelectedCategory { get; set; } = ProductCategory.None;
    }
}

