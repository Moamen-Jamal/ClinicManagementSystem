using ClinicManagement.Application;
using ClinicManagement.Application.Features.Admins.Requests;
using ClinicManagement.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AUTHORIZE(Roles = "Admin")]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }


        #region GetAllCategories
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns name="result" type="BaseCommandResponse<object>"></returns>
        [HttpGet("GetAllCategories")]
        public async Task<SharedResponse<object>> GetAllCategories()
        {
            SharedResponse<object> result = new();

            try
            {

                var categories = await _mediator.Send(new GetAllAdminsRequest());
                if (categories == null || categories.Result.Count() == 0)
                {
                    result.Successed = false;

                    result.Message = "Categories are not found";
                    ResponseMessageHelper.BadRequest(result.Message, result);
                    return result;
                }

                result.Successed = true;
                result.Data = categories;
            }
            catch
            {
                result.Successed = false;
                result.Message = "Something wrong has happened while retrieving the categories";
                ResponseMessageHelper.ServerError(result.Message, result);
            }

            return result;
        }
        #endregion



        // GET: api/<PatientController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PatientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
