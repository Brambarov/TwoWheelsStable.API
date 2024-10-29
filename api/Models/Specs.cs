using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Specs")]
    public class Specs
    {
        public int Id { get; set; }
        public string make { get; set; } = string.Empty;
        public string model { get; set; } = string.Empty;
        public string year { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string displacement { get; set; } = string.Empty;
        public string engine { get; set; } = string.Empty;
        public string power { get; set; } = string.Empty;
        public string torque { get; set; } = string.Empty;
        public string compression { get; set; } = string.Empty;
        public string bore_stroke { get; set; } = string.Empty;
        public string valves_per_cylinder { get; set; } = string.Empty;
        public string fuel_system { get; set; } = string.Empty;
        public string fuel_control { get; set; } = string.Empty;
        public string ignition { get; set; } = string.Empty;
        public string lubrication { get; set; } = string.Empty;
        public string cooling { get; set; } = string.Empty;
        public string gearbox { get; set; } = string.Empty;
        public string transmission { get; set; } = string.Empty;
        public string clutch { get; set; } = string.Empty;
        public string frame { get; set; } = string.Empty;
        public string front_suspension { get; set; } = string.Empty;
        public string front_wheel_travel { get; set; } = string.Empty;
        public string rear_suspension { get; set; } = string.Empty;
        public string rear_wheel_travel { get; set; } = string.Empty;
        public string front_tire { get; set; } = string.Empty;
        public string rear_tire { get; set; } = string.Empty;
        public string front_brakes { get; set; } = string.Empty;
        public string rear_brakes { get; set; } = string.Empty;
        public string total_weight { get; set; } = string.Empty;
        public string seat_height { get; set; } = string.Empty;
        public string total_height { get; set; } = string.Empty;
        public string total_length { get; set; } = string.Empty;
        public string total_width { get; set; } = string.Empty;
        public string ground_clearance { get; set; } = string.Empty;
        public string wheelbase { get; set; } = string.Empty;
        public string fuel_capacity { get; set; } = string.Empty;
        public string starter { get; set; } = string.Empty;
    }
}
