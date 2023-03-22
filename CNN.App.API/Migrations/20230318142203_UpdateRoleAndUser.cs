using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CNN.App.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoleAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
