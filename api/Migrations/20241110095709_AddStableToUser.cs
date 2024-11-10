using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddStableToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c69adc9-52b1-4607-94d2-d2f95848273f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aab64313-8505-406e-a64c-37e7a0f73ade");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "058feb6e-60b9-43c4-9c88-22e4c912a6f9", null, "User", "USER" },
                    { "f4c04ce1-aef8-4c30-aae4-acdf2ab81e41", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "058feb6e-60b9-43c4-9c88-22e4c912a6f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4c04ce1-aef8-4c30-aae4-acdf2ab81e41");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c69adc9-52b1-4607-94d2-d2f95848273f", null, "User", "USER" },
                    { "aab64313-8505-406e-a64c-37e7a0f73ade", null, "Admin", "ADMIN" }
                });
        }
    }
}
