using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CNN.App.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUniqueKeyOnProductCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
