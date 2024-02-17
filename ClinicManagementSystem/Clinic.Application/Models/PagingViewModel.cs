namespace ClinicManagement.Application.Models
{
    public class PagingViewModel
    {
        public int PageSize { set; get; }
        public int PageIndex { set; get; }
        public int Records { set; get; }
        public int Pages { set; get; }
        public IEnumerable<object> Result { set; get; }
    }
}
