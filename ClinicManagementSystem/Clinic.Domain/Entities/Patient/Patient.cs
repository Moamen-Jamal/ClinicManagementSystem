namespace ClinicManagement.Domain.Entities
{
    public class Patient : BaseModel
    {
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public User User { get; set; } = null!;
    }
}
