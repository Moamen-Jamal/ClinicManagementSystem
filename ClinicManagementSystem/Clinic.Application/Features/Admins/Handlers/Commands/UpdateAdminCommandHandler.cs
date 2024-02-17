using ClinicManagement.Application;
using ClinicManagement.Application.DTOs.Admin;
using ClinicManagement.Application.Features.Admins.Requests;
using ClinicManagement.Application.Models;
using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace Ecommerce.Application.Features.Admins.Handlers
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, SharedResponse<object>>
    {
        private readonly IGenericRepository<Admin> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAdminCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<Admin> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<SharedResponse<object>> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            SharedResponse<object> response = new();

            try
            {
                // Check Validator
                var valiator = new AdminValidator();
                var validatorResult = await valiator.ValidateAsync(request.AdminDto);
                if (validatorResult.IsValid == false)
                {
                    response.Successed = false;
                    response.Message = "Failed while creating the Admin item";
                    ResponseMessageHelper.BadRequest(response.Message, response);
                }
                else
                {
                    var oldAdmin = _repository.GetByIdAsync(request.AdminDto.Id);

                    if (oldAdmin == null || oldAdmin.Id <= 0)
                    {
                        response.Successed = false;
                        response.Message = "Admin is Not Found";
                        ResponseMessageHelper.BadRequest(response.Message, response);
                        return response;
                    }

                    var res = request.AdminDto.Adapt<Admin>();
                    response.Data = _repository.Update(res);
                    _unitOfWork.Commit();
                    response.Successed = true;
                    response.Message = "The Admin item is created successfully";
                }
            }
            catch
            {
                response.Successed = false;
                response.Message = "Something wrong has happened while creating the Admin item";
                ResponseMessageHelper.ServerError(response.Message, response);
            }

            return response;
        }
    }
}
