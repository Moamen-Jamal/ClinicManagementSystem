using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Models;
using MediatR;

namespace ClinicManagement.Application.Features.Users.Requests
{
    public class LoginUserCommand : IRequest<SharedResponse<object>>
    {
        public UserLoginDTO UserLoginDto { get; set; } = null!;
    }
}
