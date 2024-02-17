namespace ClinicManagement.Domain.Entities
{
    public class Review : BaseModel
    {
        public float Rate { get; set; }
        public string Comment { get; set; } = string.Empty;
        public Doctor Doctor { get; set; } = null!;
        public int DoctorId { get; set; }


    }
}
