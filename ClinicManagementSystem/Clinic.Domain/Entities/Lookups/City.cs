namespace ClinicManagement.Domain.Entities
{
    public class City : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public Governate Governate { get; set; } = null!;
        public int GovernateId { get; set; }
        public List<Region> Regions { get; set; } = new List<Region>();
    }
}
