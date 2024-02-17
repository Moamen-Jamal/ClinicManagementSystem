using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Models;
using MediatR;

namespace ClinicManagement.Application.Features.Employees.Requests
{
    public class CreateEmployeeCommand : IRequest<SharedResponse<object>>
    {
        public EmployeeDTO EmployeeDto { get; set; } = null!;
    }
}
