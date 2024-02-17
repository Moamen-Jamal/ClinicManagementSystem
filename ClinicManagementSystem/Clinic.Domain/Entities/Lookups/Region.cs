namespace ClinicManagement.Domain.Entities
{
    public class Region : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public City City { get; set; } = null!;
        public int CityId { get; set; }
        public List<Street> Streets { get; set; } = new List<Street>();
    }
}
