using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interdisciplinar2023.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cfb501dd-f67c-4537-ae32-1ec9cbf58f71"));

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: new Guid("b60cb376-d0dc-45e3-a437-9ee5c46c76ab"));

            //migrationBuilder.Sql("""ALTER TABLE "Products" ALTER COLUMN "Category" TYPE integer USING "Category"::integer""");

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Celphone", "City", "CorporateName", "CreatedAt", "Document", "Email", "Neighborhood", "Phone", "PostalCode", "State", "Street", "UpdatedAt" },
                values: new object[] { new Guid("33361a5e-0baf-41ba-89f5-f6e0568092f4"), "11933333333", "Barra Bonita", "Camil Alimentos LTDA", new DateTime(2023, 10, 28, 8, 52, 27, 551, DateTimeKind.Utc).AddTicks(6974), "64.904.295/0001-03", "alimentos@camil.com.br", "Area Rural", "1133333333", "1234567788", "São Paulo", "Fazenda Pau D'Alho, s/n", new DateTime(2023, 10, 28, 8, 52, 27, 551, DateTimeKind.Utc).AddTicks(6991) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Batch", "Category", "Corridor", "CreatedAt", "Description", "Name", "ProviderId", "Quantity", "Shelf", "UpdatedAt", "Validity", "Value" },
                values: new object[] { new Guid("b46c892e-a0c8-493b-aa8c-937d6af83924"), "L52231T", 0, "B", new DateTime(2023, 10, 28, 8, 52, 27, 551, DateTimeKind.Utc).AddTicks(7679), "Arroz Branco Tipo 1", "Arroz Branco Camil", new Guid("33361a5e-0baf-41ba-89f5-f6e0568092f4"), 20, "4", new DateTime(2023, 10, 28, 8, 52, 27, 551, DateTimeKind.Utc).AddTicks(7683), new DateTime(2024, 3, 25, 11, 50, 56, 0, DateTimeKind.Utc), 20.0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b46c892e-a0c8-493b-aa8c-937d6af83924"));

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: new Guid("33361a5e-0baf-41ba-89f5-f6e0568092f4"));

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "Celphone", "City", "CorporateName", "CreatedAt", "Document", "Email", "Neighborhood", "Phone", "PostalCode", "State", "Street", "UpdatedAt" },
                values: new object[] { new Guid("b60cb376-d0dc-45e3-a437-9ee5c46c76ab"), "11933333333", "Barra Bonita", "Camil Alimentos LTDA", new DateTime(2023, 10, 24, 3, 31, 29, 157, DateTimeKind.Utc).AddTicks(4495), "64.904.295/0001-03", "alimentos@camil.com.br", "Area Rural", "1133333333", "1234567788", "São Paulo", "Fazenda Pau D'Alho, s/n", new DateTime(2023, 10, 24, 3, 31, 29, 157, DateTimeKind.Utc).AddTicks(4514) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Batch", "Category", "Corridor", "CreatedAt", "Description", "Name", "ProviderId", "Quantity", "Shelf", "UpdatedAt", "Validity", "Value" },
                values: new object[] { new Guid("cfb501dd-f67c-4537-ae32-1ec9cbf58f71"), "L52231T", "Perecíveis", "B", new DateTime(2023, 10, 24, 3, 31, 29, 157, DateTimeKind.Utc).AddTicks(5267), "Arroz Branco Tipo 1", "Arroz Branco Camil", new Guid("b60cb376-d0dc-45e3-a437-9ee5c46c76ab"), 20, "4", new DateTime(2023, 10, 24, 3, 31, 29, 157, DateTimeKind.Utc).AddTicks(5271), new DateTime(2024, 3, 25, 11, 50, 56, 0, DateTimeKind.Utc), 20.0m });
        }
    }
}
