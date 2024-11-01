using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Specs")]
    public class Specs
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Displacement { get; set; } = string.Empty;
        public string Engine { get; set; } = string.Empty;
        public string Power { get; set; } = string.Empty;
        public string Torque { get; set; } = string.Empty;
        public string Compression { get; set; } = string.Empty;
        public string Bore_stroke { get; set; } = string.Empty;
        public string Valves_per_cylinder { get; set; } = string.Empty;
        public string Fuel_system { get; set; } = string.Empty;
        public string Fuel_control { get; set; } = string.Empty;
        public string Ignition { get; set; } = string.Empty;
        public string Lubrication { get; set; } = string.Empty;
        public string Cooling { get; set; } = string.Empty;
        public string Gearbox { get; set; } = string.Empty;
        public string Transmission { get; set; } = string.Empty;
        public string Clutch { get; set; } = string.Empty;
        public string Frame { get; set; } = string.Empty;
        public string Front_suspension { get; set; } = string.Empty;
        public string Front_wheel_travel { get; set; } = string.Empty;
        public string Rear_suspension { get; set; } = string.Empty;
        public string Rear_wheel_travel { get; set; } = string.Empty;
        public string Front_tire { get; set; } = string.Empty;
        public string Rear_tire { get; set; } = string.Empty;
        public string Front_brakes { get; set; } = string.Empty;
        public string Rear_brakes { get; set; } = string.Empty;
        public string Total_weight { get; set; } = string.Empty;
        public string Seat_height { get; set; } = string.Empty;
        public string Total_height { get; set; } = string.Empty;
        public string Total_length { get; set; } = string.Empty;
        public string Total_width { get; set; } = string.Empty;
        public string Ground_clearance { get; set; } = string.Empty;
        public string Wheelbase { get; set; } = string.Empty;
        public string Fuel_capacity { get; set; } = string.Empty;
        public string Starter { get; set; } = string.Empty;
    }
}
