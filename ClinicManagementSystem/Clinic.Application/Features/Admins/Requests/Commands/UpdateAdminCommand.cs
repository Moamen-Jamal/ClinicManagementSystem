using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Models;
using MediatR;

namespace ClinicManagement.Application.Features.Admins.Requests
{
    public class UpdateAdminCommand : IRequest<SharedResponse<object>>
    {
        public AdminDTO AdminDto { get; set; } = null!;
    }
}
