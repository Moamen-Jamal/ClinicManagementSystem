using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Models;
using MediatR;

namespace ClinicManagement.Application.Features.Admins.Requests
{
    public class CreateAdminCommand : IRequest<SharedResponse<object>>
    {
        public AdminDTO AdminDto { get; set; } = null!;
    }
}
