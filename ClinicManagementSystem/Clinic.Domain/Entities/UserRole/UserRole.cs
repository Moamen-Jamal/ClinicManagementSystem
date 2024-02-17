namespace ClinicManagement.Domain.Entities
{
    public class UserRole : BaseModel
    {
        public Role Role { get; set; } = null!;
        public int RoleId { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
    }
}
