using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15c44fe5-a67c-4e86-a89f-0978cbe31948");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40d4e75e-144f-4281-a47b-2f97ee32f393");

            migrationBuilder.CreateTable(
                name: "Specs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    displacement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    engine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    power = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    torque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    compression = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bore_stroke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valves_per_cylinder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fuel_system = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fuel_control = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ignition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lubrication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cooling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gearbox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clutch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    frame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    front_suspension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    front_wheel_travel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rear_suspension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rear_wheel_travel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    front_tire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rear_tire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    front_brakes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rear_brakes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seat_height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_width = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ground_clearance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wheelbase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fuel_capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    starter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "489a4d4e-2d92-49e8-9411-6e16251a1f84", null, "Admin", "ADMIN" },
                    { "4a05ade3-c2c3-4a52-aa61-34ab92830d18", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "489a4d4e-2d92-49e8-9411-6e16251a1f84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a05ade3-c2c3-4a52-aa61-34ab92830d18");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15c44fe5-a67c-4e86-a89f-0978cbe31948", null, "User", "USER" },
                    { "40d4e75e-144f-4281-a47b-2f97ee32f393", null, "Admin", "ADMIN" }
                });
        }
    }
}
