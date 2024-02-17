namespace ClinicManagement.Domain.Entities
{
    public class Employee : BaseModel
    {
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public User User { get; set; } = null!;
    }
}
