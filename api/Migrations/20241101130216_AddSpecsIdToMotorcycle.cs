using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecsIdToMotorcycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "489a4d4e-2d92-49e8-9411-6e16251a1f84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a05ade3-c2c3-4a52-aa61-34ab92830d18");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "Specs",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "wheelbase",
                table: "Specs",
                newName: "Wheelbase");

            migrationBuilder.RenameColumn(
                name: "valves_per_cylinder",
                table: "Specs",
                newName: "Valves_per_cylinder");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Specs",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "transmission",
                table: "Specs",
                newName: "Transmission");

            migrationBuilder.RenameColumn(
                name: "total_width",
                table: "Specs",
                newName: "Total_width");

            migrationBuilder.RenameColumn(
                name: "total_weight",
                table: "Specs",
                newName: "Total_weight");

            migrationBuilder.RenameColumn(
                name: "total_length",
                table: "Specs",
                newName: "Total_length");

            migrationBuilder.RenameColumn(
                name: "total_height",
                table: "Specs",
                newName: "Total_height");

            migrationBuilder.RenameColumn(
                name: "torque",
                table: "Specs",
                newName: "Torque");

            migrationBuilder.RenameColumn(
                name: "starter",
                table: "Specs",
                newName: "Starter");

            migrationBuilder.RenameColumn(
                name: "seat_height",
                table: "Specs",
                newName: "Seat_height");

            migrationBuilder.RenameColumn(
                name: "rear_wheel_travel",
                table: "Specs",
                newName: "Rear_wheel_travel");

            migrationBuilder.RenameColumn(
                name: "rear_tire",
                table: "Specs",
                newName: "Rear_tire");

            migrationBuilder.RenameColumn(
                name: "rear_suspension",
                table: "Specs",
                newName: "Rear_suspension");

            migrationBuilder.RenameColumn(
                name: "rear_brakes",
                table: "Specs",
                newName: "Rear_brakes");

            migrationBuilder.RenameColumn(
                name: "power",
                table: "Specs",
                newName: "Power");

            migrationBuilder.RenameColumn(
                name: "model",
                table: "Specs",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "make",
                table: "Specs",
                newName: "Make");

            migrationBuilder.RenameColumn(
                name: "lubrication",
                table: "Specs",
                newName: "Lubrication");

            migrationBuilder.RenameColumn(
                name: "ignition",
                table: "Specs",
                newName: "Ignition");

            migrationBuilder.RenameColumn(
                name: "ground_clearance",
                table: "Specs",
                newName: "Ground_clearance");

            migrationBuilder.RenameColumn(
                name: "gearbox",
                table: "Specs",
                newName: "Gearbox");

            migrationBuilder.RenameColumn(
                name: "fuel_system",
                table: "Specs",
                newName: "Fuel_system");

            migrationBuilder.RenameColumn(
                name: "fuel_control",
                table: "Specs",
                newName: "Fuel_control");

            migrationBuilder.RenameColumn(
                name: "fuel_capacity",
                table: "Specs",
                newName: "Fuel_capacity");

            migrationBuilder.RenameColumn(
                name: "front_wheel_travel",
                table: "Specs",
                newName: "Front_wheel_travel");

            migrationBuilder.RenameColumn(
                name: "front_tire",
                table: "Specs",
                newName: "Front_tire");

            migrationBuilder.RenameColumn(
                name: "front_suspension",
                table: "Specs",
                newName: "Front_suspension");

            migrationBuilder.RenameColumn(
                name: "front_brakes",
                table: "Specs",
                newName: "Front_brakes");

            migrationBuilder.RenameColumn(
                name: "frame",
                table: "Specs",
                newName: "Frame");

            migrationBuilder.RenameColumn(
                name: "engine",
                table: "Specs",
                newName: "Engine");

            migrationBuilder.RenameColumn(
                name: "displacement",
                table: "Specs",
                newName: "Displacement");

            migrationBuilder.RenameColumn(
                name: "cooling",
                table: "Specs",
                newName: "Cooling");

            migrationBuilder.RenameColumn(
                name: "compression",
                table: "Specs",
                newName: "Compression");

            migrationBuilder.RenameColumn(
                name: "clutch",
                table: "Specs",
                newName: "Clutch");

            migrationBuilder.RenameColumn(
                name: "bore_stroke",
                table: "Specs",
                newName: "Bore_stroke");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Specs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SpecsId",
                table: "Motorcycles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32101ed5-5667-4ae1-ae54-48df6927d227", null, "Admin", "ADMIN" },
                    { "9ae023cc-4206-49a5-abdb-813b87db36f4", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_SpecsId",
                table: "Motorcycles",
                column: "SpecsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Specs_SpecsId",
                table: "Motorcycles",
                column: "SpecsId",
                principalTable: "Specs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Specs_SpecsId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_SpecsId",
                table: "Motorcycles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32101ed5-5667-4ae1-ae54-48df6927d227");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ae023cc-4206-49a5-abdb-813b87db36f4");

            migrationBuilder.DropColumn(
                name: "SpecsId",
                table: "Motorcycles");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Specs",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "Wheelbase",
                table: "Specs",
                newName: "wheelbase");

            migrationBuilder.RenameColumn(
                name: "Valves_per_cylinder",
                table: "Specs",
                newName: "valves_per_cylinder");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Specs",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Transmission",
                table: "Specs",
                newName: "transmission");

            migrationBuilder.RenameColumn(
                name: "Total_width",
                table: "Specs",
                newName: "total_width");

            migrationBuilder.RenameColumn(
                name: "Total_weight",
                table: "Specs",
                newName: "total_weight");

            migrationBuilder.RenameColumn(
                name: "Total_length",
                table: "Specs",
                newName: "total_length");

            migrationBuilder.RenameColumn(
                name: "Total_height",
                table: "Specs",
                newName: "total_height");

            migrationBuilder.RenameColumn(
                name: "Torque",
                table: "Specs",
                newName: "torque");

            migrationBuilder.RenameColumn(
                name: "Starter",
                table: "Specs",
                newName: "starter");

            migrationBuilder.RenameColumn(
                name: "Seat_height",
                table: "Specs",
                newName: "seat_height");

            migrationBuilder.RenameColumn(
                name: "Rear_wheel_travel",
                table: "Specs",
                newName: "rear_wheel_travel");

            migrationBuilder.RenameColumn(
                name: "Rear_tire",
                table: "Specs",
                newName: "rear_tire");

            migrationBuilder.RenameColumn(
                name: "Rear_suspension",
                table: "Specs",
                newName: "rear_suspension");

            migrationBuilder.RenameColumn(
                name: "Rear_brakes",
                table: "Specs",
                newName: "rear_brakes");

            migrationBuilder.RenameColumn(
                name: "Power",
                table: "Specs",
                newName: "power");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Specs",
                newName: "model");

            migrationBuilder.RenameColumn(
                name: "Make",
                table: "Specs",
                newName: "make");

            migrationBuilder.RenameColumn(
                name: "Lubrication",
                table: "Specs",
                newName: "lubrication");

            migrationBuilder.RenameColumn(
                name: "Ignition",
                table: "Specs",
                newName: "ignition");

            migrationBuilder.RenameColumn(
                name: "Ground_clearance",
                table: "Specs",
                newName: "ground_clearance");

            migrationBuilder.RenameColumn(
                name: "Gearbox",
                table: "Specs",
                newName: "gearbox");

            migrationBuilder.RenameColumn(
                name: "Fuel_system",
                table: "Specs",
                newName: "fuel_system");

            migrationBuilder.RenameColumn(
                name: "Fuel_control",
                table: "Specs",
                newName: "fuel_control");

            migrationBuilder.RenameColumn(
                name: "Fuel_capacity",
                table: "Specs",
                newName: "fuel_capacity");

            migrationBuilder.RenameColumn(
                name: "Front_wheel_travel",
                table: "Specs",
                newName: "front_wheel_travel");

            migrationBuilder.RenameColumn(
                name: "Front_tire",
                table: "Specs",
                newName: "front_tire");

            migrationBuilder.RenameColumn(
                name: "Front_suspension",
                table: "Specs",
                newName: "front_suspension");

            migrationBuilder.RenameColumn(
                name: "Front_brakes",
                table: "Specs",
                newName: "front_brakes");

            migrationBuilder.RenameColumn(
                name: "Frame",
                table: "Specs",
                newName: "frame");

            migrationBuilder.RenameColumn(
                name: "Engine",
                table: "Specs",
                newName: "engine");

            migrationBuilder.RenameColumn(
                name: "Displacement",
                table: "Specs",
                newName: "displacement");

            migrationBuilder.RenameColumn(
                name: "Cooling",
                table: "Specs",
                newName: "cooling");

            migrationBuilder.RenameColumn(
                name: "Compression",
                table: "Specs",
                newName: "compression");

            migrationBuilder.RenameColumn(
                name: "Clutch",
                table: "Specs",
                newName: "clutch");

            migrationBuilder.RenameColumn(
                name: "Bore_stroke",
                table: "Specs",
                newName: "bore_stroke");

            migrationBuilder.AlterColumn<string>(
                name: "year",
                table: "Specs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "489a4d4e-2d92-49e8-9411-6e16251a1f84", null, "Admin", "ADMIN" },
                    { "4a05ade3-c2c3-4a52-aa61-34ab92830d18", null, "User", "USER" }
                });
        }
    }
}
