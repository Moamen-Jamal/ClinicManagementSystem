using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Features.Employees.Requests;
using ClinicManagement.Application.Models;
using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using Mapster;
using MediatR;

namespace ClinicManagement.Application.Features.Employees.Handlers;

public class GetAllEmployeesRequestHandler : IRequestHandler<GetAllEmployeesRequest, PagingViewModel>
    {
        private readonly IGenericRepository<Employee> _repository;

        public GetAllEmployeesRequestHandler(IGenericRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<PagingViewModel> Handle(GetAllEmployeesRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Employee>? query;

            if (!string.IsNullOrEmpty(request.Name))
                query = _repository.Get(i => i.User.Name.Contains(request.Name));
            else
                query = _repository.GetAllIncluding(null, i => i.User);

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
                query = query.OrderBy(i => i.Id);

            query = query.Skip(excludedRows).Take(request.PageSize);

            var employeesDtos = query.ProjectToType<EmployeeDTO>().ToList();
            return new PagingViewModel()
            { PageIndex = request.PageIndex, PageSize = request.PageSize, Result = employeesDtos, Records = records, Pages = pages };

        }
    }

