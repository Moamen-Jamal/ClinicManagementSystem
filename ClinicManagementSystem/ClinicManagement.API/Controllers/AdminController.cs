using ClinicManagement.Application;
using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Features.Admins.Requests;
using ClinicManagement.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Context;
using System;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AUTHORIZE(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Serilog.ILogger _log = Log.ForContext<AdminController>();
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region GetFilteredAdmins
        /// <summary>
        /// Get Filtered Admins
        /// </summary>
        /// <returns name="result" type="SharedResponse<object>"></returns>
        [HttpGet("Get")]
        public async Task<SharedResponse<object>> GetFilteredAdmins(int pageIndex = 0, int pageSize = 6,
              string? name = "", bool isDescinding = false)
        {
            SharedResponse<object> result = new();
            Guid correlationId = Guid.NewGuid();

            try
            {

                _log.ForContext("Details", correlationId.ToString());
                _log.Information("Get Filtered Admins started -----> AdminController ------> GetFilteredAdmins");

                var adminsPagination = await _mediator.Send(new GetAllAdminsRequest { PageIndex = pageIndex, PageSize = pageSize,
                    Name = name, IsDescinding = isDescinding});
                if (adminsPagination == null || adminsPagination.Result.Count() == 0)
                {
                    result.Successed = false;

                    result.Message = "Admins are not found";
                    ResponseMessageHelper.BadRequest(result.Message, result);
                    _log.Error(result.Message);
                    return result;
                }

                result.Successed = true;
                result.Data = adminsPagination;
            }
            catch (Exception ex)
            {
                result.Successed = false;
                result.Message = ex.Message;
                ResponseMessageHelper.ServerError(result.Message, result);
                _log.Error(ex,result.Message);
            }

            return result;
        }
        #endregion


        #region GetAdminById
        /// <summary>
        /// Get Admin By Id
        /// </summary>
        /// <returns name="result" type="SharedResponse<object>"></returns>
        [HttpGet("Get/{id}")]
        public async Task<SharedResponse<object>> GetAdminById(int id)
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

                var admin = await _mediator.Send(new GetAdminDetailsRequest { Id = id });

                if (admin == null || admin?.Id <= 0)
                {
                    result.Successed = false;
                    result.Message = "The admin is not found.";
                    ResponseMessageHelper.BadRequest(result.Message, result);
                    return result;
                }

                result.Successed = true;
                result.Data = admin;
            }
            catch
            {
                result.Successed = false;
                result.Message = "Something wrong has happened while retrieving the admin";
                ResponseMessageHelper.ServerError(result.Message, result);

            }

            return result;
        }
        #endregion



        #region Add New Admin
        /// <summary>
        /// Add New Admin
        /// </summary>
        /// <returns name="response" type="SharedResponse<object>"></returns>
        [HttpPost("AddNewAdmin")]
        public async Task<SharedResponse<object>> AddNewAdmin([FromBody] AdminDTO adminDto)
        {
            SharedResponse<object> response = new();
            try
            {
                var createAdminCommand = new CreateAdminCommand { AdminDto = adminDto };
                response = await _mediator.Send(createAdminCommand);
            }
            catch
            {
                response.Successed = false;
                response.Message = "Something wrong has happened while retrieving the admin";
                ResponseMessageHelper.ServerError(response.Message, response);
            }

            return response;
        }
        #endregion

        #region Update Admin
        /// <summary>
        /// Update Exist Admin
        /// </summary>
        /// <returns name="response" type="SharedResponse<object>"></returns>
        [HttpPut("UpdateAdmin")]
        public async Task<SharedResponse<object>> UpdateAdmin([FromBody] AdminDTO adminDto)
        {
            SharedResponse<object> response = new();
            try
            {
                var updateAdminCommand = new UpdateAdminCommand { AdminDto = adminDto };
                response = await _mediator.Send(updateAdminCommand);
            }
            catch
            {
                response.Successed = false;
                response.Message = "Something wrong has happened while retrieving the admin";
                ResponseMessageHelper.ServerError(response.Message, response);
            }
            return response;
        }
        #endregion

        #region Delete Admin
        /// <summary>
        /// Delete Exist Admin
        /// </summary>
        /// <returns name="response" type="SharedResponse<object>"></returns>
        [HttpDelete("DeleteAdminById/{id}")]
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
                var deleteCommand = new DeleteAdminCommand { Id = id };
                response = await _mediator.Send(deleteCommand);
                response.Successed = true;
                response.Message = "Admin has been deleted successfully";
            }
            catch
            {
                response.Successed = false;
                response.Message = "Something wrong has happened while deleting the admin";
                ResponseMessageHelper.ServerError(response.Message, response);

            }


            return response;
        }
        #endregion

    }
}
