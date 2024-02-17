using ClinicManagement.Application.DTOs;
using ClinicManagement.Application.Models;
using ClinicManagement.Application;
using Microsoft.AspNetCore.Mvc;
using ClinicManagement.Application.Features.Users.Requests;
using MediatR;

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Login User
        /// <summary>
        /// Login User
        /// </summary>
        /// <returns name="response" type="SharedResponse<object>"></returns>
        [HttpPost("Login")]
        public async Task<SharedResponse<object>> Login(UserLoginDTO userLoginDto)
        {
            SharedResponse<object> response = new();
            try
            {
                var loginUserCommand = new LoginUserCommand { UserLoginDto = userLoginDto };
                response = await _mediator.Send(loginUserCommand);
            }
            catch
            {
                response.Successed = false;
                response.Message = "Something wrong has happened while logining";
                ResponseMessageHelper.ServerError(response.Message, response);
            }

            return response;
        }
        #endregion
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
