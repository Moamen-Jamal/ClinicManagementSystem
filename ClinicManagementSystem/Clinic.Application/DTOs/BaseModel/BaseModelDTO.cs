namespace ClinicManagement.Application.DTOs
{
    public abstract class BaseModelDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
