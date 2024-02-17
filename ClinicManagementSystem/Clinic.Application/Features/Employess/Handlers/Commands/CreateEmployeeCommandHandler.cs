using ClinicManagement.Application;
using ClinicManagement.Application.DTOs.Employee;
using ClinicManagement.Application.Features.Employees.Requests;
using ClinicManagement.Application.Models;
using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace Ecommerce.Application.Features.Employees.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, SharedResponse<object>>
    {
        private readonly IGenericRepository<Employee> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Employee> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<SharedResponse<object>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            SharedResponse<object> response = new ();

            try
            {
                // Check Validator
                var valiator = new EmployeeValidator();
                var validatorResult = await valiator.ValidateAsync(request.EmployeeDto);
                if (validatorResult.IsValid == false)
                {
                    response.Successed = false;
                    response.Message = "Failed while creating the Employee item";
                    ResponseMessageHelper.BadRequest(response.Message, response);
                }
                else
                {
                    var Employee = request.EmployeeDto.Adapt<Employee>();
                    var EmployeeEntity =  _repository.Create(Employee);
                     _unitOfWork.Commit();
                    response.Successed = true;
                    response.Message = "The Employee item is created successfully";
                    response.Data = EmployeeEntity;
                }
            }
            catch
            {
                response.Successed = false;
                response.Message = "Something wrong has happened while creating the Employee item";
                ResponseMessageHelper.ServerError(response.Message, response);
            }
                    
            return response;
        }

    }
}
