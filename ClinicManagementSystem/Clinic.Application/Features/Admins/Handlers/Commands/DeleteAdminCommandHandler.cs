using ClinicManagement.Application;
using ClinicManagement.Application.Features.Admins.Requests;
using ClinicManagement.Application.Models;
using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Features.Admins.Handlers
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, SharedResponse<object>>
    {
        private readonly IGenericRepository<Admin> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAdminCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Admin> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<SharedResponse<object>> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            SharedResponse<object> response = new();
            try
            {
                //get Admin by id
                var oldAdmin = _repository.GetByIdAsync(request.Id);

                if (oldAdmin == null || oldAdmin.Id <= 0)
                {
                    response.Successed = false;
                    response.Message = "Admin is Not Found";
                    ResponseMessageHelper.BadRequest(response.Message, response);
                    return response;
                }
                _repository.DeleteById(oldAdmin.Id);
                _unitOfWork.Commit();
                response.Successed = true;
                response.Message = "The Admin item is deleted successfully";
            }
            catch
            {
                response.Successed = false;
                response.Message = "Something wrong has happened while deleting the Admin item";
                ResponseMessageHelper.ServerError(response.Message, response);
            }
            
            return response;
        }

    }
}
