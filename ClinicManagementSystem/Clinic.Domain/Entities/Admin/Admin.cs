namespace ClinicManagement.Domain.Entities
{
    public class Admin : BaseModel
    {
        public User User { get; set; } = null!;
    }
}
