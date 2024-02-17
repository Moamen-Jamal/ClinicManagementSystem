using ClinicManagement.Application;
using ClinicManagement.Application.Features.Employees.Requests;
using ClinicManagement.Application.Models;
using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Features.Employees.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, SharedResponse<object>>
    {
        private readonly IGenericRepository<Employee> _repository;
        private readonly IGenericRepository<User> _repoUser;
        private readonly IGenericRepository<UserRole> _repoUserRole;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Employee> repository, IGenericRepository<User> repoUser, IGenericRepository<UserRole> repoUserRole)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _repoUser = repoUser;
            _repoUserRole = repoUserRole;
        }
        public async Task<SharedResponse<object>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            SharedResponse<object> response = new();
            try
            {
                //get Employee by id
                var oldEmployee = _repository.GetByIdAsync(request.Id);

                if (oldEmployee == null || oldEmployee.Id <= 0)
                {
                    response.Successed = false;
                    response.Message = "Employee is Not Found";
                    ResponseMessageHelper.BadRequest(response.Message, response);
                    return response;
                }
                UserRole userRole = _repoUserRole.GetAll().Where(i => i.UserId == request.Id).FirstOrDefault();
                _repoUserRole.DeleteById(userRole.Id);
                _repoUser.DeleteById(oldEmployee.Id);
                _repository.DeleteById(oldEmployee.Id);
                _unitOfWork.Commit();
                response.Successed = true;
                response.Message = "The Employee item is deleted successfully";
            }
            catch
            {
                response.Successed = false;
                response.Message = "Something wrong has happened while deleting the Employee item";
                ResponseMessageHelper.ServerError(response.Message, response);
            }
            
            return response;
        }

    }
}
