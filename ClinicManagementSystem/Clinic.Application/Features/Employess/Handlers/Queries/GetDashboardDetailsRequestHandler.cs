using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Features.Employees.Requests;
using ClinicManagement.Application.Features.Employess.Requests;
using ClinicManagement.Application.Persistence.Abstractions;
using ClinicManagement.Domain.Entities;
using MediatR;

namespace ClinicManagement.Application.Features.Employess.Handlers
{
    public class GetDashboardDetailsRequestHandler : IRequestHandler<GetDashboardDetailsRequest, DashboardDTO>
    {
        private readonly IGenericRepository<Employee> _repoEmployee;
        private readonly IGenericRepository<Doctor> _repoDoctor;
        private readonly IGenericRepository<Patient> _repoPatient;
        private readonly IGenericRepository<Appointment> _repoAppointment;

        public GetDashboardDetailsRequestHandler(IGenericRepository<Employee> repoEmployee, IGenericRepository<Doctor> repoDoctor, 
            IGenericRepository<Patient> repoPatient, IGenericRepository<Appointment> repoAppointment)
        {
            _repoEmployee = repoEmployee;
            _repoDoctor = repoDoctor;
            _repoPatient = repoPatient;
            _repoAppointment = repoAppointment;
        }


        public Task<DashboardDTO> Handle(GetDashboardDetailsRequest request, CancellationToken cancellationToken)
        {
            DashboardDTO report = new();
            try
            {
                report.TotalDoctors = _repoDoctor.GetAll().Count();
                report.TotalAppointments = _repoAppointment.GetAll().Count();
                report.TotalPatients = _repoPatient.GetAll().Count();
                report.TotalEmployees = _repoEmployee.GetAll().Count();
            }
            catch (Exception ex)
            {

            }
            return Task.FromResult(report);
        }
    }
}
