using ClinicManagement.Application.Models;
using MediatR;

namespace ClinicManagement.Application.Features.Employees.Requests
{
    public class DeleteEmployeeCommand : IRequest<SharedResponse<object>>
    {
        public int Id { get; set; }
    }
}
