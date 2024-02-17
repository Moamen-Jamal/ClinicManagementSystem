namespace ClinicManagement.Domain.Entities
{
    public class Address : BaseModel
    {
        public string Description { get; set; } = string.Empty;
        public Street Street { get; set; } = null!;
        public int StreetId { get; set; }
        public Clinic Clinic { get; set; } = null!;
        public int ClinicId { get; set; }
    }
}
