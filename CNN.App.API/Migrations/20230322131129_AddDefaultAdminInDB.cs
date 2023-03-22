using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CNN.App.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultAdminInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Name",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValueSql: "N'CN' + FORMAT(NEXT VALUE FOR ProductCodes, '000000')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "N'CN' + FORMAT(NEXT VALUE FOR ProductCodes, '000000')");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "LongName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("14e422b0-5313-4f83-94e8-7916131a4f26"), null, "Storekeeper", "STORE", "STORE" },
                    { new Guid("210740d3-4da4-4889-9cbc-990a19ccf780"), null, "Administrator", "ADMIN", "ADMIN" },
                    { new Guid("3de4d7f6-89ca-4056-b9c2-0646bac33e81"), null, "Simple user", "SIMPLE", "SIMPLE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "FirstName", "IsActivate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[] { new Guid("1286870a-099c-4d1a-a113-cb9c756b5311"), 0, new DateTime(2023, 3, 22, 13, 11, 29, 668, DateTimeKind.Utc).AddTicks(8278), "00afe9fc-62fd-4e48-947e-3a34e7db5826", new DateTime(2023, 3, 22, 14, 11, 29, 668, DateTimeKind.Local).AddTicks(8223), null, null, false, "admin", true, "admin", false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEIS5SicxJ8fdfmVmCJS9v0JwpsiAIpYHZq/FNwpAdVFPYMYDnpS9qTAJLMRB0N99gQ==", null, false, "default\\default-user.png", null, false, null, "admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("d7c8b4ec-004b-4949-b509-2541df2d971b"), "", "Category" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("210740d3-4da4-4889-9cbc-990a19ccf780"), new Guid("1286870a-099c-4d1a-a113-cb9c756b5311") });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("14e422b0-5313-4f83-94e8-7916131a4f26"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3de4d7f6-89ca-4056-b9c2-0646bac33e81"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("210740d3-4da4-4889-9cbc-990a19ccf780"), new Guid("1286870a-099c-4d1a-a113-cb9c756b5311") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d7c8b4ec-004b-4949-b509-2541df2d971b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("210740d3-4da4-4889-9cbc-990a19ccf780"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1286870a-099c-4d1a-a113-cb9c756b5311"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "N'CN' + FORMAT(NEXT VALUE FOR ProductCodes, '000000')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValueSql: "N'CN' + FORMAT(NEXT VALUE FOR ProductCodes, '000000')");

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
    }
}
