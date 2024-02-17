using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Features.Admins.Requests;
using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace Ecommerce.Application.Features.Categories.Handlers
{
    public class GetAdminDetailsRequestHandler : IRequestHandler<GetAdminDetailsRequest, AdminDTO>
    {
        private readonly IGenericRepository<Admin> _repository;

        public GetAdminDetailsRequestHandler(IGenericRepository<Admin> repository)
        {
            _repository = repository;
        }


        public async Task<AdminDTO> Handle(GetAdminDetailsRequest request, CancellationToken cancellationToken)
        {
            var admin = _repository.GetByIdAsync(request.Id);
            return admin.Adapt<AdminDTO>();
        }
    }
}
