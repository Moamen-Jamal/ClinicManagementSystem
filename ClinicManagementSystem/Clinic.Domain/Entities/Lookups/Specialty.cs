namespace ClinicManagement.Domain.Entities
{
    public class Specialty : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
