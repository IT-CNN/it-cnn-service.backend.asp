using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CNN.App.API.Migrations
{
    /// <inheritdoc />
    public partial class AddClientEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "LongName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3d4ada61-b06d-44d9-a770-b03bbbfb924f"), null, "Administrator", "ADMIN", "ADMIN" },
                    { new Guid("799b43dc-ddb5-4981-a9d6-e155fe765ed6"), null, "Simple user", "SIMPLE", "SIMPLE" },
                    { new Guid("9006630d-a5cf-4087-9e83-32a34355910a"), null, "Storekeeper", "STORE", "STORE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "CreatedAt", "DeletedAt", "Email", "EmailConfirmed", "FirstName", "IsActivate", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[] { new Guid("7401736f-4c1f-44de-b76c-a72eb789d6f4"), 0, new DateTime(2023, 3, 28, 14, 3, 22, 288, DateTimeKind.Utc).AddTicks(4466), "d748742d-4d31-49f2-b51b-96c8e82be0fc", new DateTime(2023, 3, 28, 15, 3, 22, 288, DateTimeKind.Local).AddTicks(4419), null, null, false, "admin", true, "admin", false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEAqFUAR6kYj4co5rXy1FNRkCjl5jCABSHYN16yMq105z4CTM5OISt4wFM/bTfmHi9Q==", null, false, "default\\default-user.png", null, false, null, "admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("4f0e3ecc-7fde-4e6a-a98d-5160282a7db8"), "", "Category" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "Name", "PhoneNumber", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("18c7f39d-2fe9-43bf-8524-0e4591772fa9"), new DateTime(2023, 3, 28, 15, 3, 22, 376, DateTimeKind.Local).AddTicks(4933), null, true, "client 5", "690981060", null },
                    { new Guid("5112ab74-b816-4a57-9603-8a91344147ec"), new DateTime(2023, 3, 28, 15, 3, 22, 376, DateTimeKind.Local).AddTicks(4931), null, true, "client 4", "690981059", null },
                    { new Guid("54c7aa39-1333-4132-920d-180a1cc52938"), new DateTime(2023, 3, 28, 15, 3, 22, 376, DateTimeKind.Local).AddTicks(4908), null, true, "client 1", "690981056", null },
                    { new Guid("5979fc9f-03d4-4d4b-8894-26b6b766df99"), new DateTime(2023, 3, 28, 15, 3, 22, 376, DateTimeKind.Local).AddTicks(4928), null, true, "client 3", "690981058", null },
                    { new Guid("90ec0c0f-2fc5-4796-ae6c-207fd0e38aba"), new DateTime(2023, 3, 28, 15, 3, 22, 376, DateTimeKind.Local).AddTicks(4926), null, true, "client 2", "690981057", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3d4ada61-b06d-44d9-a770-b03bbbfb924f"), new Guid("7401736f-4c1f-44de-b76c-a72eb789d6f4") });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PhoneNumber",
                table: "Clients",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("799b43dc-ddb5-4981-a9d6-e155fe765ed6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9006630d-a5cf-4087-9e83-32a34355910a"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3d4ada61-b06d-44d9-a770-b03bbbfb924f"), new Guid("7401736f-4c1f-44de-b76c-a72eb789d6f4") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f0e3ecc-7fde-4e6a-a98d-5160282a7db8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d4ada61-b06d-44d9-a770-b03bbbfb924f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7401736f-4c1f-44de-b76c-a72eb789d6f4"));

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
        }
    }
}
