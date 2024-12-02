using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeScheduleToJobsForMotorcycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "384e5b1a-51fb-42c7-8530-a53636bc5183");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d6b1df3-7c50-4d0a-bccf-ef7c05121e33");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ef10e38-8e1d-40d7-9029-10bd4afa5361", null, "Admin", "ADMIN" },
                    { "5f44f4fd-c21f-41bd-9c95-97adcf28bf49", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ef10e38-8e1d-40d7-9029-10bd4afa5361");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f44f4fd-c21f-41bd-9c95-97adcf28bf49");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "384e5b1a-51fb-42c7-8530-a53636bc5183", null, "Admin", "ADMIN" },
                    { "4d6b1df3-7c50-4d0a-bccf-ef7c05121e33", null, "User", "USER" }
                });
        }
    }
}
