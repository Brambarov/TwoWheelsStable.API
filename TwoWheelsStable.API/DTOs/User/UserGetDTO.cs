﻿using api.DTOs.Motorcycle;

namespace api.DTOs.User
{
    public class UserGetDTO
    {
        public string Href { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public List<MotorcycleGetDTO> Motorcycles { get; set; } = [];
    }
}
