using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToMotorcycleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e46048b-cc39-4d2d-bbcf-78b77c247e1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85944e2b-d309-473e-963c-69d44b043ee5");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Motorcycles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c69adc9-52b1-4607-94d2-d2f95848273f", null, "User", "USER" },
                    { "aab64313-8505-406e-a64c-37e7a0f73ade", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_UserId",
                table: "Motorcycles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_AspNetUsers_UserId",
                table: "Motorcycles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_AspNetUsers_UserId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_UserId",
                table: "Motorcycles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c69adc9-52b1-4607-94d2-d2f95848273f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aab64313-8505-406e-a64c-37e7a0f73ade");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Motorcycles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e46048b-cc39-4d2d-bbcf-78b77c247e1e", null, "Admin", "ADMIN" },
                    { "85944e2b-d309-473e-963c-69d44b043ee5", null, "User", "USER" }
                });
        }
    }
}
