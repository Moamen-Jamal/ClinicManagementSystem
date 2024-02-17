using ClinicManagement.Application;
using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Features.Employees.Requests;
using ClinicManagement.Application.Features.Employess.Requests;
using ClinicManagement.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AUTHORIZE(Roles = "Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CustomLogger _customLogger;
        public EmployeeController(IMediator mediator, CustomLogger customLogger)
        {
            _mediator = mediator;
            _customLogger = customLogger;
        }

        #region GetFilteredEmployees
        /// <summary>
        /// Get Filtered Employees
        /// </summary>
        /// <returns name="result" type="SharedResponse<object>"></returns>
        [HttpGet("Get")]
        public async Task<SharedResponse<object>> GetFilteredEmployees(int pageIndex = 0, int pageSize = 6,
              string? name = "", bool isDescinding = false)
        {
            SharedResponse<object> result = new();
            Guid correlationId = Guid.NewGuid();

            try
            {
                _customLogger.ForContext("Details", correlationId.ToString())
                    .Information("Get Filtered Employees started -----> EmployeeController ------> GetFilteredEmployees");

                var EmployeesPagination = await _mediator.Send(new GetAllEmployeesRequest
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    Name = name,
                    IsDescinding = isDescinding
                });
                if (EmployeesPagination == null || EmployeesPagination.Result.Count() == 0)
                {
                    result.Successed = false;

                    result.Message = "Employees are not found";
                    ResponseMessageHelper.BadRequest(result.Message, result);
                    _customLogger.Error(result.Message);
                    return result;
                }

                result.Successed = true;
                result.Data = EmployeesPagination;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = ex.Message;
                ResponseMessageHelper.ServerError(result.Message, result);
                _customLogger.Error(ex, result.Message);
            }

            return result;
        }
        #endregion


        #region GetEmployeeById
        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <returns name="result" type="SharedResponse<object>"></returns>
        [HttpGet("Get/{id}")]
        public async Task<SharedResponse<object>> GetEmployeeById(int id)
        {
            SharedResponse<object> result = new();

            try
            {
                if (id <= 0)
                {
                    result.Successed = false;
                    result.Message = "Id is not valid";
                    ResponseMessageHelper.BadRequest(result.Message, result);
                    return result;
                }

                var Employee = await _mediator.Send(new GetEmployeeDetailsRequest { Id = id });

                if (Employee == null || Employee?.Id <= 0)
                {
                    result.Successed = false;
                    result.Message = "The Employee is not found.";
                    ResponseMessageHelper.BadRequest(result.Message, result);
                    return result;
                }

                result.Successed = true;
                result.Data = Employee;
            }
            catch
            {
                result.Successed = false;
                result.Message = "Something wrong has happened while retrieving the Employee";
                ResponseMessageHelper.ServerError(result.Message, result);

            }

            return result;
        }
        #endregion



        #region Add New Employee
        /// <summary>
        /// Add New Employee
        /// </summary>
        /// <returns name="response" type="SharedResponse<object>"></returns>
        [HttpPost("Post")]
        public async Task<SharedResponse<object>> AddNewEmployee([FromBody] EmployeeDTO EmployeeDto)
        {
            SharedResponse<object> response = new();
            try
            {
                var createEmployeeCommand = new CreateEmployeeCommand { EmployeeDto = EmployeeDto };
                response = await _mediator.Send(createEmployeeCommand);
            }
            catch
            {
                response.Successed = false;
                response.Message = "Something wrong has happened while retrieving the Employee";
                ResponseMessageHelper.ServerError(response.Message, response);
            }

            return response;
        }
        #endregion

        #region Update Employee
        /// <summary>
        /// Update Exist Employee
        /// </summary>
        /// <returns name="response" type="SharedResponse<object>"></returns>
        [HttpPut("Put")]
        public async Task<SharedResponse<object>> UpdateEmployee([FromBody] EmployeeDTO EmployeeDto)
        {
            SharedResponse<object> response = new();
            try
            {
                var updateEmployeeCommand = new UpdateEmployeeCommand { EmployeeDto = EmployeeDto };
                response = await _mediator.Send(updateEmployeeCommand);
            }
            catch
            {
                response.Successed = false;
                response.Message = "Something wrong has happened while retrieving the Employee";
                ResponseMessageHelper.ServerError(response.Message, response);
            }
            return response;
        }
        #endregion

        #region Delete Employee
        /// <summary>
        /// Delete Exist Employee
        /// </summary>
        /// <returns name="response" type="SharedResponse<object>"></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<SharedResponse<object>> Delete(int id)
        {
            SharedResponse<object> response = new();
            try
            {
                if (id <= 0)
                {
                    response.Successed = false;
                    response.Message = "Id is not valid";
                    ResponseMessageHelper.BadRequest(response.Message, response);
                    return response;
                }
                var deleteCommand = new DeleteEmployeeCommand { Id = id };
                response = await _mediator.Send(deleteCommand);
                response.Successed = true;
                response.Message = "Employee has been deleted successfully";
            }
            catch
            {
                response.Successed = false;
                response.Message = "Something wrong has happened while deleting the Employee";
                ResponseMessageHelper.ServerError(response.Message, response);

            }


            return response;
        }
        #endregion

        [HttpGet("GetDashboardDetails")]
        public async Task<SharedResponse<object>> GetDashboardDetails()
        {
            SharedResponse<object> result = new();

            try
            {
                var reports = await _mediator.Send(new GetDashboardDetailsRequest { });
                if (reports == null)
                {
                    result.Successed = false;
                    result.Message = "The reports data are not found.";
                    ResponseMessageHelper.BadRequest(result.Message, result);
                    return result;
                }
                result.Data = reports;
                result.Successed = true;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = "Something wrong has happened while retrieving the dashboard data";
                ResponseMessageHelper.ServerError(result.Message, result);
            }
            return result;
        }
    }
}
