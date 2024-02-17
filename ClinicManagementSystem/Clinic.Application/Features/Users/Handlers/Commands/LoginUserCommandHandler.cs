using ClinicManagement.Application;
using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.DTOs.User;
using ClinicManagement.Application.Features.Users.Requests;
using ClinicManagement.Application.Models;
using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace Ecommerce.Application.Features.Users.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, SharedResponse<object>>
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IGenericRepository<Role> _repositoryRole;

        public LoginUserCommandHandler(IGenericRepository<User> repository, IGenericRepository<Role> repositoryRole)
        {
            _repository = repository;
            _repositoryRole = repositoryRole;
        }
        public async Task<SharedResponse<object>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            SharedResponse<object> response = new ();

            try
            {
                // Check Validator
                var valiator = new UserLoginValidator();
                var validatorResult = await valiator.ValidateAsync(request.UserLoginDto);
                if (validatorResult.IsValid == false)
                {
                    response.Successed = false;
                    if (validatorResult.Errors.Any())
                        response.Message = string.Join(" ", validatorResult.Errors.Select(i => i.ErrorMessage).ToList());
                    else
                        response.Message = "Failed while Login";
                    ResponseMessageHelper.BadRequest(response.Message, response);
                }
                else
                {
                    UserDTO? result = null;
                    //User? selectedUser =
                    //    _repository.Get(i => i.UserName == request.UserLoginDto.UserName
                    //    && i.Password == request.UserLoginDto.Password).FirstOrDefault();
                    User? selectedUser = _repository.GetAllIncluding(i => i.UserName == request.UserLoginDto.UserName
                        && i.Password == request.UserLoginDto.Password, i => i.UserRoles).FirstOrDefault();

                    if (selectedUser == null)
                    {
                        response.Successed = false;
                        response.Message = "The username or password is not correct";
                        return response;

                    }

                    result = new UserDTO();
                    result = selectedUser.Adapt<UserDTO>();
                    Role? Role = _repositoryRole.GetByIdAsync(selectedUser.UserRoles.FirstOrDefault().RoleId);
                    result.Role = Role.Name;
                    result.Password = string.Empty;
                    result.Token = SecurityHelper.GenerateToken(selectedUser);

                    response.Successed = true;
                    response.Message = "The user logined successfully";
                    response.Data = result;

                    return response;
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
