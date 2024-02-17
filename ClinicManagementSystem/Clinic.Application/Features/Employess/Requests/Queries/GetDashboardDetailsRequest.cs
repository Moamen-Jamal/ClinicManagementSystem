using ClinicManagement.Application.DTOs;
using MediatR;

namespace ClinicManagement.Application.Features.Employess.Requests
{
    public class GetDashboardDetailsRequest : IRequest<DashboardDTO>
    {
    }
}
