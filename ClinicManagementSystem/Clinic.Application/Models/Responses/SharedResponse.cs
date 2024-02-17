using System.Net;

namespace ClinicManagement.Application.Models
{
    public class SharedResponse<T>
    {
        public SharedResponse()
        {
            Status = (int)HttpStatusCode.OK;
        }

        public SharedResponse(int Status)
        {
            this.Status = Status;
        }

        public bool Successed { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Status { get; set; }
        public T? Data { get; set; }
    }
}
