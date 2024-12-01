using api.DTOs.Specs;
using api.Models;

namespace api.Helpers.Mappers
{
    public static class SpecsMapper
    {
        public static SpecsGetDTO ToGetDTO(this Specs model)
        {
            return new SpecsGetDTO
            {
                Id = model.Id,
                Type = model.Type,
                Displacement = model.Displacement,
                Engine = model.Engine,
                Power = model.Power,
                Torque = model.Torque,
                Compression = model.Compression,
                BoreStroke = model.Bore_stroke,
                ValvesPerCylinder = model.Valves_per_cylinder,
                FuelSystem = model.Fuel_system,
                FuelControl = model.Fuel_control,
                Ignition = model.Ignition,
                Lubrication = model.Lubrication,
                Cooling = model.Cooling,
                Gearbox = model.Gearbox,
                Transmission = model.Transmission,
                Clutch = model.Clutch,
                Frame = model.Frame,
                FrontSuspension = model.Front_suspension,
                FrontWheelTravel = model.Front_wheel_travel,
                RearSuspension = model.Rear_suspension,
                RearWheelTravel = model.Rear_wheel_travel,
                FrontTire = model.Front_tire,
                RearTire = model.Rear_tire,
                FrontBrakes = model.Front_brakes,
                RearBrakes = model.Rear_brakes,
                TotalWeight = model.Total_weight,
                SeatHeight = model.Seat_height,
                TotalHeight = model.Total_height,
                TotalLength = model.Total_length,
                TotalWidth = model.Total_width,
                GroundClearance = model.Ground_clearance,
                Wheelbase = model.Wheelbase,
                FuelCapacity = model.Fuel_capacity,
                Starter = model.Starter
            };
        }
    }
}
