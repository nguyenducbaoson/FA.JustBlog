using FA.JustBlog.API.Models;
using FA.JustBlog.Responsitory.IResponsitory;
using FA.JustBlog.ViewModel.Login;
using FA.JustBlog.ViewModel.Register;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FA.JustBlog.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserResponsitory userResponsitory;
        protected APIResponse _response;
        public UserController(IUserResponsitory userResponsitory)
        {
            this.userResponsitory = userResponsitory;
            this._response = new();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var LoginResponse = await userResponsitory.Login(model);
            if (LoginResponse.User == null || string.IsNullOrEmpty(LoginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("User or password is incorrect !");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = LoginResponse;
            return Ok(_response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequest model)
        {
            bool ifUserNameUnique = userResponsitory.IsUniqueUser(model.UserName);
            if (!ifUserNameUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists !");
                return BadRequest(_response);
            }
            var user = await userResponsitory.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Error while registering !");
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
