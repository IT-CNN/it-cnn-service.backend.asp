using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CNN.App.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductCodeGeneration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("18e10b2f-181d-4a9c-846b-0773ca47eadf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d8bdd4ef-01ac-4d60-b0f6-c17fd6562c01"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dab9dacb-2276-4858-b38d-b17fd5e3e970"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("72ffbd65-9834-46e4-89a5-c2a991686bdb"));

            migrationBuilder.CreateSequence<int>(
                name: "ProductCodes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "LongName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("29466b1d-ec6f-416f-a2af-1916c405afb2"), null, "Storekeeper", "STORE", "STORE" },
                    { new Guid("6f11ced2-2684-4da3-be37-335c3971e9ed"), null, "Administrator", "ADMIN", "ADMIN" },
                    { new Guid("91a2661f-0f6d-4f7e-a6d8-17ff4bf4992a"), null, "Simple user", "SIMPLE", "SIMPLE" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("fba20ce0-c0d9-4097-a0dc-ba0ebc7bd2c0"), "", "Category" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("29466b1d-ec6f-416f-a2af-1916c405afb2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6f11ced2-2684-4da3-be37-335c3971e9ed"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("91a2661f-0f6d-4f7e-a6d8-17ff4bf4992a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fba20ce0-c0d9-4097-a0dc-ba0ebc7bd2c0"));

            migrationBuilder.DropSequence(
                name: "ProductCodes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "LongName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("18e10b2f-181d-4a9c-846b-0773ca47eadf"), null, "Simple user", "SIMPLE", "SIMPLE" },
                    { new Guid("d8bdd4ef-01ac-4d60-b0f6-c17fd6562c01"), null, "Storekeeper", "STORE", "STORE" },
                    { new Guid("dab9dacb-2276-4858-b38d-b17fd5e3e970"), null, "Administrator", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("72ffbd65-9834-46e4-89a5-c2a991686bdb"), "", "Category" });
        }
    }
}
