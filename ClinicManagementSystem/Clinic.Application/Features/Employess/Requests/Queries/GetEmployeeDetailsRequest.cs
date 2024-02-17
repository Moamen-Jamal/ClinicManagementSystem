using ClinicManagement.Application.DTOs;
using MediatR;

namespace ClinicManagement.Application.Features.Employees.Requests
{
    public class GetEmployeeDetailsRequest : IRequest<EmployeeDTO>
    {
        public int Id { get; set; }
    }
}
