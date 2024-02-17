namespace ClinicManagement.Domain.Entities
{
    public class Street : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public Region Region { get; set; } = null!;
        public int RegionId { get; set; }
        public virtual List<Address> Addresses { get; set; } = new List<Address>();
    }
}
