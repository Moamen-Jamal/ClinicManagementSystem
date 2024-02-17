using ClinicManagement.Application;
using ClinicManagement.Application.Features.Employees.Requests;
using ClinicManagement.Application.Models;
using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace Ecommerce.Application.Features.Employees.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, SharedResponse<object>>
    {
        private readonly IGenericRepository<Employee> _repoEmployee;
        private readonly IGenericRepository<User> _repoUser;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Employee> repoEmployee, IGenericRepository<User> repoUser)
        {
            _unitOfWork = unitOfWork;
            _repoEmployee = repoEmployee;
            _repoUser = repoUser;
        }

        public async Task<SharedResponse<object>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            SharedResponse<object> response = new();

            try
            {

                var res = request.EmployeeDto.Adapt<Employee>();
                _repoUser.Update(res.User);
                _repoEmployee.Update(res);
                //response.Data = _repoEmployee.Update(res);
                _unitOfWork.Commit();
                response.Successed = true;
                response.Message = "The Employee item is created successfully";
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
