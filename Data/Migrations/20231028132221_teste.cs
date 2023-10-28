using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interdisciplinar2023.Data.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b46c892e-a0c8-493b-aa8c-937d6af83924"));

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: new Guid("33361a5e-0baf-41ba-89f5-f6e0568092f4"));

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Celphone", "City", "CorporateName", "CreatedAt", "Document", "Email", "Neighborhood", "Phone", "PostalCode", "State", "Street", "UpdatedAt" },
                values: new object[] { new Guid("0234fd0e-189e-4bb4-a652-e605b563bec8"), "11933333333", "Barra Bonita", "Camil Alimentos LTDA", new DateTime(2023, 10, 28, 13, 22, 21, 92, DateTimeKind.Utc).AddTicks(4722), "64.904.295/0001-03", "alimentos@camil.com.br", "Area Rural", "1133333333", "1234567788", "São Paulo", "Fazenda Pau D'Alho, s/n", new DateTime(2023, 10, 28, 13, 22, 21, 92, DateTimeKind.Utc).AddTicks(4743) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Batch", "Category", "Corridor", "CreatedAt", "Description", "Name", "ProviderId", "Quantity", "Shelf", "UpdatedAt", "Validity", "Value" },
                values: new object[] { new Guid("a96ae17a-d2e4-40b4-97dc-bdb1eb2c6d9b"), "L52231T", 0, "B", new DateTime(2023, 10, 28, 13, 22, 21, 92, DateTimeKind.Utc).AddTicks(5483), "Arroz Branco Tipo 1", "Arroz Branco Camil", new Guid("0234fd0e-189e-4bb4-a652-e605b563bec8"), 20, "4", new DateTime(2023, 10, 28, 13, 22, 21, 92, DateTimeKind.Utc).AddTicks(5487), new DateTime(2024, 3, 25, 11, 50, 56, 0, DateTimeKind.Utc), 20.0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a96ae17a-d2e4-40b4-97dc-bdb1eb2c6d9b"));

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: new Guid("0234fd0e-189e-4bb4-a652-e605b563bec8"));

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Celphone", "City", "CorporateName", "CreatedAt", "Document", "Email", "Neighborhood", "Phone", "PostalCode", "State", "Street", "UpdatedAt" },
                values: new object[] { new Guid("33361a5e-0baf-41ba-89f5-f6e0568092f4"), "11933333333", "Barra Bonita", "Camil Alimentos LTDA", new DateTime(2023, 10, 28, 8, 52, 27, 551, DateTimeKind.Utc).AddTicks(6974), "64.904.295/0001-03", "alimentos@camil.com.br", "Area Rural", "1133333333", "1234567788", "São Paulo", "Fazenda Pau D'Alho, s/n", new DateTime(2023, 10, 28, 8, 52, 27, 551, DateTimeKind.Utc).AddTicks(6991) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Batch", "Category", "Corridor", "CreatedAt", "Description", "Name", "ProviderId", "Quantity", "Shelf", "UpdatedAt", "Validity", "Value" },
                values: new object[] { new Guid("b46c892e-a0c8-493b-aa8c-937d6af83924"), "L52231T", 0, "B", new DateTime(2023, 10, 28, 8, 52, 27, 551, DateTimeKind.Utc).AddTicks(7679), "Arroz Branco Tipo 1", "Arroz Branco Camil", new Guid("33361a5e-0baf-41ba-89f5-f6e0568092f4"), 20, "4", new DateTime(2023, 10, 28, 8, 52, 27, 551, DateTimeKind.Utc).AddTicks(7683), new DateTime(2024, 3, 25, 11, 50, 56, 0, DateTimeKind.Utc), 20.0m });
        }
    }
}
