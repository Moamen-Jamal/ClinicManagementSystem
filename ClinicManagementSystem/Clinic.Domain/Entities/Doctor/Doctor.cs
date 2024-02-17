namespace ClinicManagement.Domain.Entities
{
    public class Doctor : BaseModel
    {
        public int Age { get; set; }
        public decimal Fees { get; set; }
        public string Education { get; set; } = string.Empty;
        public float TotalRate { get; set; }
        public Specialty Specialty { get; set; } = null!;
        public int SpecialtyId { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Clinic> Clinics { get; set; } = new List<Clinic>();
        public User User { get; set; } = null!;


    }
}
