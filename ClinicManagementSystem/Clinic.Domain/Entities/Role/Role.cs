namespace ClinicManagement.Domain.Entities
{
    public class Role : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
