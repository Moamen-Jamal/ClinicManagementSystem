namespace ClinicManagement.Domain.Entities
{
    public class TimeOfClinicWork : BaseModel
    {
        public string Day { get; set; } = string.Empty;
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public Clinic Clinic { get; set; } = null!;
        public int ClinicId { get; set; }
    }
}
