using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Features.Admins.Requests;
using ClinicManagement.Application.Models;
using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace ClinicManagement.Application.Features.Admins.Handlers;

public class GetAllAdminsRequestHandler : IRequestHandler<GetAllAdminsRequest, PagingViewModel>
{
    private readonly IGenericRepository<Admin> _repository;

    public GetAllAdminsRequestHandler(IGenericRepository<Admin> repository)
    {
        _repository = repository;
    }

    public async Task<PagingViewModel> Handle(GetAllAdminsRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Admin>? query;

        if (!string.IsNullOrEmpty(request.Name))
            query = _repository.Get(i => i.User.Name.Contains(request.Name));
        else
            query = _repository.GetAll();

        if (request.IsDescinding == true)
            query = query.OrderByDescending(i => i.Id);

        if (!string.IsNullOrEmpty(request.Name))
            query = _repository.Get(i => i.User.Name.Contains(request.Name));

        int records = query.Count();
        if (records <= request.PageSize || request.PageIndex <= 0)
            request.PageIndex = 1;
        int pages = (int)Math.Ceiling((double)records / request.PageSize);
        int excludedRows = (request.PageIndex - 1) * request.PageSize;

        if (!request.IsDescinding)
            query =  query.OrderBy(i => i.Id);

        query = query.Skip(excludedRows).Take(request.PageSize);

        var adminsDtos = query.ProjectToType<AdminDTO>().ToList();
        return new PagingViewModel()
        { PageIndex = request.PageIndex, PageSize = request.PageSize, Result = adminsDtos, Records = records, Pages = pages };

    }
}
