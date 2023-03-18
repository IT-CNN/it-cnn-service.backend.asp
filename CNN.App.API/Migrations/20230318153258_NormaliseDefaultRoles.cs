using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CNN.App.API.Migrations
{
    /// <inheritdoc />
    public partial class NormaliseDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("86f5fee5-f876-4377-a103-48fc4ee36642"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8902b1fe-d7d5-4e5e-9113-1348c6226004"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d95a9f1d-aaa9-4447-9ffd-7d69346b7ed1"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "LongName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("563d0e8e-0b11-4ffa-b11e-4356b071855e"), null, "Simple user", "SIMPLE", "SIMPLE" },
                    { new Guid("b646d62f-5a95-46bd-ab9e-459c8b42be88"), null, "Administrator", "ADMIN", "ADMIN" },
                    { new Guid("d503a1db-2a0a-4524-b3f9-52af6d993548"), null, "Storekeeper", "STORE", "STORE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("563d0e8e-0b11-4ffa-b11e-4356b071855e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b646d62f-5a95-46bd-ab9e-459c8b42be88"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d503a1db-2a0a-4524-b3f9-52af6d993548"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "LongName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("86f5fee5-f876-4377-a103-48fc4ee36642"), null, "Storekeeper", "STORE", null },
                    { new Guid("8902b1fe-d7d5-4e5e-9113-1348c6226004"), null, "Simple user", "SIMPLE", null },
                    { new Guid("d95a9f1d-aaa9-4447-9ffd-7d69346b7ed1"), null, "Administrator", "ADMIN", null }
                });
        }
    }
}
