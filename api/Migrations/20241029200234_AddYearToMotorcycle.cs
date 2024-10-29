using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddYearToMotorcycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68ab83bc-82b4-40cf-a534-f4a506968cad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fba25f20-3052-4f2e-9f58-dee20dd2fa36");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Motorcycles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15c44fe5-a67c-4e86-a89f-0978cbe31948", null, "User", "USER" },
                    { "40d4e75e-144f-4281-a47b-2f97ee32f393", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15c44fe5-a67c-4e86-a89f-0978cbe31948");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40d4e75e-144f-4281-a47b-2f97ee32f393");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Motorcycles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68ab83bc-82b4-40cf-a534-f4a506968cad", null, "Admin", "ADMIN" },
                    { "fba25f20-3052-4f2e-9f58-dee20dd2fa36", null, "User", "USER" }
                });
        }
    }
}
