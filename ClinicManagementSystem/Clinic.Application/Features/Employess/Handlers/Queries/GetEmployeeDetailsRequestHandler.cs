using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Features.Employees.Requests;
using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace Ecommerce.Application.Features.Categories.Handlers
{
    public class GetEmployeeDetailsRequestHandler : IRequestHandler<GetEmployeeDetailsRequest, EmployeeDTO>
    {
        private readonly IGenericRepository<Employee> _repository;

        public GetEmployeeDetailsRequestHandler(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }


        public async Task<EmployeeDTO> Handle(GetEmployeeDetailsRequest request, CancellationToken cancellationToken)
        {
            var Employee = _repository.GetByIdAsync(request.Id, i => i.User);
            var employeeDTO = Employee.Adapt<EmployeeDTO>();
            employeeDTO.Password = "";
            return employeeDTO;
        }
    }
}
