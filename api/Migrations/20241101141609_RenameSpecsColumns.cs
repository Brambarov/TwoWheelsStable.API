using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RenameSpecsColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Specs_SpecsId",
                table: "Motorcycles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32101ed5-5667-4ae1-ae54-48df6927d227");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ae023cc-4206-49a5-abdb-813b87db36f4");

            migrationBuilder.RenameColumn(
                name: "Valves_per_cylinder",
                table: "Specs",
                newName: "ValvesPerCylinder");

            migrationBuilder.RenameColumn(
                name: "Total_width",
                table: "Specs",
                newName: "TotalWidth");

            migrationBuilder.RenameColumn(
                name: "Total_weight",
                table: "Specs",
                newName: "TotalWeight");

            migrationBuilder.RenameColumn(
                name: "Total_length",
                table: "Specs",
                newName: "TotalLength");

            migrationBuilder.RenameColumn(
                name: "Total_height",
                table: "Specs",
                newName: "TotalHeight");

            migrationBuilder.RenameColumn(
                name: "Seat_height",
                table: "Specs",
                newName: "SeatHeight");

            migrationBuilder.RenameColumn(
                name: "Rear_wheel_travel",
                table: "Specs",
                newName: "RearWheelTravel");

            migrationBuilder.RenameColumn(
                name: "Rear_tire",
                table: "Specs",
                newName: "RearTire");

            migrationBuilder.RenameColumn(
                name: "Rear_suspension",
                table: "Specs",
                newName: "RearSuspension");

            migrationBuilder.RenameColumn(
                name: "Rear_brakes",
                table: "Specs",
                newName: "RearBrakes");

            migrationBuilder.RenameColumn(
                name: "Ground_clearance",
                table: "Specs",
                newName: "GroundClearance");

            migrationBuilder.RenameColumn(
                name: "Fuel_system",
                table: "Specs",
                newName: "FuelSystem");

            migrationBuilder.RenameColumn(
                name: "Fuel_control",
                table: "Specs",
                newName: "FuelControl");

            migrationBuilder.RenameColumn(
                name: "Fuel_capacity",
                table: "Specs",
                newName: "FuelCapacity");

            migrationBuilder.RenameColumn(
                name: "Front_wheel_travel",
                table: "Specs",
                newName: "FrontWheelTravel");

            migrationBuilder.RenameColumn(
                name: "Front_tire",
                table: "Specs",
                newName: "FrontTire");

            migrationBuilder.RenameColumn(
                name: "Front_suspension",
                table: "Specs",
                newName: "FrontSuspension");

            migrationBuilder.RenameColumn(
                name: "Front_brakes",
                table: "Specs",
                newName: "FrontBrakes");

            migrationBuilder.RenameColumn(
                name: "Bore_stroke",
                table: "Specs",
                newName: "BoreStroke");

            migrationBuilder.AlterColumn<int>(
                name: "SpecsId",
                table: "Motorcycles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e46048b-cc39-4d2d-bbcf-78b77c247e1e", null, "Admin", "ADMIN" },
                    { "85944e2b-d309-473e-963c-69d44b043ee5", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Specs_SpecsId",
                table: "Motorcycles",
                column: "SpecsId",
                principalTable: "Specs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Specs_SpecsId",
                table: "Motorcycles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e46048b-cc39-4d2d-bbcf-78b77c247e1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85944e2b-d309-473e-963c-69d44b043ee5");

            migrationBuilder.RenameColumn(
                name: "ValvesPerCylinder",
                table: "Specs",
                newName: "Valves_per_cylinder");

            migrationBuilder.RenameColumn(
                name: "TotalWidth",
                table: "Specs",
                newName: "Total_width");

            migrationBuilder.RenameColumn(
                name: "TotalWeight",
                table: "Specs",
                newName: "Total_weight");

            migrationBuilder.RenameColumn(
                name: "TotalLength",
                table: "Specs",
                newName: "Total_length");

            migrationBuilder.RenameColumn(
                name: "TotalHeight",
                table: "Specs",
                newName: "Total_height");

            migrationBuilder.RenameColumn(
                name: "SeatHeight",
                table: "Specs",
                newName: "Seat_height");

            migrationBuilder.RenameColumn(
                name: "RearWheelTravel",
                table: "Specs",
                newName: "Rear_wheel_travel");

            migrationBuilder.RenameColumn(
                name: "RearTire",
                table: "Specs",
                newName: "Rear_tire");

            migrationBuilder.RenameColumn(
                name: "RearSuspension",
                table: "Specs",
                newName: "Rear_suspension");

            migrationBuilder.RenameColumn(
                name: "RearBrakes",
                table: "Specs",
                newName: "Rear_brakes");

            migrationBuilder.RenameColumn(
                name: "GroundClearance",
                table: "Specs",
                newName: "Ground_clearance");

            migrationBuilder.RenameColumn(
                name: "FuelSystem",
                table: "Specs",
                newName: "Fuel_system");

            migrationBuilder.RenameColumn(
                name: "FuelControl",
                table: "Specs",
                newName: "Fuel_control");

            migrationBuilder.RenameColumn(
                name: "FuelCapacity",
                table: "Specs",
                newName: "Fuel_capacity");

            migrationBuilder.RenameColumn(
                name: "FrontWheelTravel",
                table: "Specs",
                newName: "Front_wheel_travel");

            migrationBuilder.RenameColumn(
                name: "FrontTire",
                table: "Specs",
                newName: "Front_tire");

            migrationBuilder.RenameColumn(
                name: "FrontSuspension",
                table: "Specs",
                newName: "Front_suspension");

            migrationBuilder.RenameColumn(
                name: "FrontBrakes",
                table: "Specs",
                newName: "Front_brakes");

            migrationBuilder.RenameColumn(
                name: "BoreStroke",
                table: "Specs",
                newName: "Bore_stroke");

            migrationBuilder.AlterColumn<int>(
                name: "SpecsId",
                table: "Motorcycles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32101ed5-5667-4ae1-ae54-48df6927d227", null, "Admin", "ADMIN" },
                    { "9ae023cc-4206-49a5-abdb-813b87db36f4", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Specs_SpecsId",
                table: "Motorcycles",
                column: "SpecsId",
                principalTable: "Specs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
