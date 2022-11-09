using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/User")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }


        /// <summary>
        /// used to authenticate user and returns user access token and route details
        /// </summary>
        /// <param name="credentials">object contains user name and password</param>
        /// <remarks> 
        /// </remarks>
        [HttpPost]
        [Route("authenticateUserDetails")]
        [RequireAuthorization]
        public IActionResult AuthenticateUserDetails(AuthenticationDto credentials) {
            var user = _usersService.AuthorizeUserDetails(credentials.UserName, credentials.Password);

            return JsonExt(user);
        }


        /// <summary>
        /// used to get user details by access token.
        /// </summary>
        /// <param name="accessToken">The access token generated for the login session</param>
        /// <remarks>
        /// </remarks>
        [HttpGet]
        [Route("GetUserInfoByToken/{accessToken}")]
        [RequireAuthorization]      
        public IActionResult GetUserInfoByToken(string accessToken) {
            var user = _usersService.GetUserByAccessToken(accessToken.ToString());
            return JsonExt(user);
        }

    }
}
