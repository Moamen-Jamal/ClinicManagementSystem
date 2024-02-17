using ClinicManagement.Application.DTOs;
using MediatR;

namespace ClinicManagement.Application.Features.Admins.Requests
{
    public class GetAdminDetailsRequest : IRequest<AdminDTO>
    {
        public int Id { get; set; }
    }
}
