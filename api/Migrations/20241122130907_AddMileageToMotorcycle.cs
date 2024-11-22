using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddMileageToMotorcycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62627c85-f24d-4b9f-ac0e-cf68d059708f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abfc7fa2-aecb-49d6-93bc-6536797fc718");

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Motorcycles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13123f98-17d2-4c4b-9a2d-2542a7e3884c", null, "Admin", "ADMIN" },
                    { "33a5c652-df44-4c4a-ac71-4a3a524e380d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13123f98-17d2-4c4b-9a2d-2542a7e3884c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33a5c652-df44-4c4a-ac71-4a3a524e380d");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Motorcycles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62627c85-f24d-4b9f-ac0e-cf68d059708f", null, "User", "USER" },
                    { "abfc7fa2-aecb-49d6-93bc-6536797fc718", null, "Admin", "ADMIN" }
                });
        }
    }
}
