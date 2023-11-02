using Interdisciplinar2023.Data.Enum;

namespace Interdisciplinar2023.Extensions;


public static class ProductCategoryExtension
{
    public static string Translate(this ProductCategory value) => value switch
    {
        ProductCategory.None => "Nenhuma",
        ProductCategory.Bebidas => "Bebidas",
        ProductCategory.Higiene => "Higiene",
        ProductCategory.Mercearia => "Mercearia",
        ProductCategory.Hortifruti => "Hortifruti",
        ProductCategory.Pereciveis => "Perecíveis",
        _ => throw new ArgumentOutOfRangeException(nameof(value), $"Valor Não esperado: {value}")
    };
}

