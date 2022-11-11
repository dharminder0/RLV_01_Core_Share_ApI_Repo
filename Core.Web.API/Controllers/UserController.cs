using Core.Business.Entites.RequestModels;
using Core.Business.Entites.ResponseModels;
using Core.Business.Services.Abstract;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/User")]
    [ApiController]
    public class UserController : BaseApiController {
        private readonly IUsersService _usersService;
        public UserController(IUsersService usersService) {
            _usersService = usersService;
        }


        /// <summary>
        /// used to authenticate user 
        /// </summary>
        /// <param name="credentials">object contains user name and password</param>
        /// <remarks> 
        /// </remarks>
        [HttpPost]
        [Route("login")]
        [RequireAuthorization]
        public IActionResult Userlogin(AuthenticationDto credentials) {
            var user = _usersService.Userlogin(credentials.UserName, credentials.Password);
            return JsonExt(user);
        }


        /// <summary>
        /// used to get user details by access token.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <remarks>
        /// </remarks>
        [HttpGet]
        [Route("info/{accessToken}")]
        [RequireAuthorization]
        public IActionResult GetUserInfoByToken(string accessToken) {
            var user = _usersService.GetUserInfoByToken(accessToken);
            return JsonExt(user);
        }

        /// <summary>
        /// used to get user details by id.
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// </remarks>
        [HttpGet]
        [Route("infoById/{id}")]
        [RequireAuthorization]
        public IActionResult UsersInfoById(int id) {
            var response = _usersService.UsersInfoById(id);
            return JsonExt(response);
        }

        /// <summary>
        /// ada update user
        /// </summary>
        /// <param name="obj"></param>
        /// <remarks>
        /// </remarks>
        [HttpPost]
        [Route("add")]
        [RequireAuthorization]
        public IActionResult AddUpdateUser(RequestUser obj) {
            var response = _usersService.AddUpdateUser(obj);
            return JsonExt(response);
        }
    }
}
