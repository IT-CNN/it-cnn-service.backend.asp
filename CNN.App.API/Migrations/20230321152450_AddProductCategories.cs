using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CNN.App.API.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1dcb0dc7-7292-4662-a3f8-82aaa84ea051"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3c7c4c13-b120-4ac2-af10-a43d2b82a0ff"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a925bafd-7752-48b2-8fcb-169f0a94fff9"));

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Quantities",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesProducts",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProducId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesProducts", x => new { x.CategoryId, x.ProducId });
                    table.ForeignKey(
                        name: "FK_CategoriesProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesProducts_Products_ProducId",
                        column: x => x.ProducId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "LongName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("58b11c60-ed0e-4004-8058-5ef97eac2c0e"), null, "Administrator", "ADMIN", "ADMIN" },
                    { new Guid("610bf915-e8d9-4755-b391-1fd1c5bad8b7"), null, "Storekeeper", "STORE", "STORE" },
                    { new Guid("a7c68fdb-b38e-4d92-949e-236da110a88c"), null, "Simple user", "SIMPLE", "SIMPLE" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("259d8961-8347-4626-b704-4b096a23d4d3"), "", "Category" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesProducts_ProducId",
                table: "CategoriesProducts",
                column: "ProducId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesProducts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("58b11c60-ed0e-4004-8058-5ef97eac2c0e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("610bf915-e8d9-4755-b391-1fd1c5bad8b7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a7c68fdb-b38e-4d92-949e-236da110a88c"));

            migrationBuilder.AlterColumn<float>(
                name: "Value",
                table: "Quantities",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "LongName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1dcb0dc7-7292-4662-a3f8-82aaa84ea051"), null, "Simple user", "SIMPLE", "SIMPLE" },
                    { new Guid("3c7c4c13-b120-4ac2-af10-a43d2b82a0ff"), null, "Administrator", "ADMIN", "ADMIN" },
                    { new Guid("a925bafd-7752-48b2-8fcb-169f0a94fff9"), null, "Storekeeper", "STORE", "STORE" }
                });
        }
    }
}
