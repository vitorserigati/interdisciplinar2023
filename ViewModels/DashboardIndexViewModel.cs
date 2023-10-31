using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Interdisciplinar2023.Models;

namespace Interdisciplinar2023.ViewModels;

public class DashboardIndexViewModel
{
    [DisplayName("Selecione Uma Data")]
    [DisplayFormat(DataFormatString = "dd/MM/yyyy HH:mm")]
    public DateTime? SelectedDate { get; set; }

    public IEnumerable<Product>? Products { get; set; }

    [Display(Name = "Selecione um Fornecedor")]
    public string? SelectedProviderId { get; set; }

    public IEnumerable<Provider>? Providers { get; set; }
}
