namespace ClinicManagement.Domain.Entities
{
    public class Appointment : BaseModel
    {
        public string Day { get; set; } = string.Empty;
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public bool IsComplete { get; set; }
        public Patient Patient { get; set; } = null!;
        public int PatientId { get; set; }
        public Clinic Clinic { get; set; } = null!;
        public int ClinicId { get; set; }
    }
}
