﻿namespace ClinicManagement.Application.DTOs
{
    public class UserDTO : BaseModelDTO
    {
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }
}
