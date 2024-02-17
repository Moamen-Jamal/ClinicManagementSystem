using ClinicManagement.Application.Models;
using MediatR;

namespace ClinicManagement.Application.Features.Admins.Requests
{
    public class DeleteAdminCommand : IRequest<SharedResponse<object>>
    {
        public int Id { get; set; }
    }
}
