using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "058feb6e-60b9-43c4-9c88-22e4c912a6f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4c04ce1-aef8-4c30-aae4-acdf2ab81e41");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Specs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Motorcycles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62627c85-f24d-4b9f-ac0e-cf68d059708f", null, "User", "USER" },
                    { "abfc7fa2-aecb-49d6-93bc-6536797fc718", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62627c85-f24d-4b9f-ac0e-cf68d059708f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abfc7fa2-aecb-49d6-93bc-6536797fc718");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Specs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "058feb6e-60b9-43c4-9c88-22e4c912a6f9", null, "User", "USER" },
                    { "f4c04ce1-aef8-4c30-aae4-acdf2ab81e41", null, "Admin", "ADMIN" }
                });
        }
    }
}
