using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Models;
using MediatR;

namespace ClinicManagement.Application.Features.Employees.Requests
{
    public class GetAllEmployeesRequest : IRequest<PagingViewModel>
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 6;
        public string? Name { get; set; } = string.Empty;
        public bool IsDescinding { get; set; }
    }
}
