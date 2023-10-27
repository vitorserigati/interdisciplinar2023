using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Interdisciplinar2023.Models;

namespace Interdisciplinar2023.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        string input = "25/03/2024 8:50:56 AM";
        CultureInfo info = new CultureInfo("pt-BR");
        var provider = new Provider
        {
            Id = Guid.NewGuid(),
            Document = "64.904.295/0001-03",
            CorporateName = "Camil Alimentos LTDA",
            Street = "Fazenda Pau D'Alho, s/n",
            Neighborhood = "Area Rural",
            City = "Barra Bonita",
            State = "São Paulo",
            PostalCode = "1234567788",
            Email = "alimentos@camil.com.br",
            Phone = "1133333333",
            Celphone = "11933333333",
            CreatedAt = DateTime.Now.ToUniversalTime(),
            UpdatedAt = DateTime.Now.ToUniversalTime()
                
        };

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = "Arroz Branco Camil",
            Value = 20.0m,
            Corridor = "B",
            Shelf = "4",
            Batch = "L52231T",
            Validity = DateTime.Parse(input, info, DateTimeStyles.None).ToUniversalTime(),
            Category = "Perecíveis",
            Description = "Arroz Branco Tipo 1",
            Quantity = 20,
            ProviderId = provider.Id,
            CreatedAt = DateTime.Now.ToUniversalTime(),
            UpdatedAt = DateTime.Now.ToUniversalTime()
        };

        modelBuilder.Entity<Provider>().HasData(provider);
        modelBuilder.Entity<Product>().HasData(product);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Provider> Providers { get; set; }
    public DbSet<Product> Products { get; set; }
}

