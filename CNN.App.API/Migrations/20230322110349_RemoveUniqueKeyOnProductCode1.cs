using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CNN.App.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueKeyOnProductCode1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Code",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2807b8ed-2a00-4978-a870-01276acc9fcf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6252ff99-3b13-4d40-92fd-4d2de7425ee7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c2ffb8d5-b011-41e1-a750-8f7b07df4d91"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f10a0865-5266-4946-b887-b7b8e976c7f9"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "N'CN' + FORMAT(NEXT VALUE FOR ProductCodes, '000000')",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "CONCAT('CN', FORMAT(NEXT VALUE FOR ProductCodes, '000000'))");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "LongName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1a8c8891-7696-4ea8-ab82-36ca1bbd7c43"), null, "Simple user", "SIMPLE", "SIMPLE" },
                    { new Guid("73cfdc8e-529d-4047-8fad-cbeb1a9173ed"), null, "Storekeeper", "STORE", "STORE" },
                    { new Guid("e2f1d4ed-aeb5-4086-af19-d6ac8cf53389"), null, "Administrator", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("d076ded8-61b4-4420-ae2f-3493d855cffb"), "", "Category" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1a8c8891-7696-4ea8-ab82-36ca1bbd7c43"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("73cfdc8e-529d-4047-8fad-cbeb1a9173ed"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2f1d4ed-aeb5-4086-af19-d6ac8cf53389"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d076ded8-61b4-4420-ae2f-3493d855cffb"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "CONCAT('CN', FORMAT(NEXT VALUE FOR ProductCodes, '000000'))",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "N'CN' + FORMAT(NEXT VALUE FOR ProductCodes, '000000')");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "LongName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2807b8ed-2a00-4978-a870-01276acc9fcf"), null, "Administrator", "ADMIN", "ADMIN" },
                    { new Guid("6252ff99-3b13-4d40-92fd-4d2de7425ee7"), null, "Simple user", "SIMPLE", "SIMPLE" },
                    { new Guid("c2ffb8d5-b011-41e1-a750-8f7b07df4d91"), null, "Storekeeper", "STORE", "STORE" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("f10a0865-5266-4946-b887-b7b8e976c7f9"), "", "Category" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                table: "Products",
                column: "Code",
                unique: true);
        }
    }
}
