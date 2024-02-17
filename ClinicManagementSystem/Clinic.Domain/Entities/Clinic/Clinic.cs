namespace ClinicManagement.Domain.Entities
{
    public class Clinic : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Doctor Doctor { get; set; } = null!;
        public int DoctorId { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<TimeOfClinicWork> TimeOfClinicWorks { get; set; } = new List<TimeOfClinicWork>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
