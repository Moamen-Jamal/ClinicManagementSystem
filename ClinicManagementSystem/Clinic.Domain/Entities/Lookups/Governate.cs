namespace ClinicManagement.Domain.Entities
{
    public class Governate : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public List<City> Cities { get; set; } = new List<City>();
    }
}
