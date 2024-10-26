using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddMotorcycleName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6103075b-7a9a-4c2d-ae65-5990541cb58d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a5fe3f7-4914-4d40-9419-5e8b866943b1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Motorcycles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03dde8e3-6b6f-4b84-b259-c094f223c34f", null, "Admin", "ADMIN" },
                    { "130b843c-8a5d-4980-91d2-41148bd3df58", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03dde8e3-6b6f-4b84-b259-c094f223c34f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "130b843c-8a5d-4980-91d2-41148bd3df58");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Motorcycles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6103075b-7a9a-4c2d-ae65-5990541cb58d", null, "User", "USER" },
                    { "7a5fe3f7-4914-4d40-9419-5e8b866943b1", null, "Admin", "ADMIN" }
                });
        }
    }
}
