namespace ClinicManagement.Domain.Entities
{
    public class User : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public Patient Patient { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
        public Admin Admin { get; set; } = null!;
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
