using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Core.Business.Services.Abstract;
using Core.Business.Services.Concrete;
using System.Net;
using Core.Business.Entites.RequestModels;

namespace Core.Web.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUsersService _userService;
        public UserController(IUsersService usersService)
        {
            _userService = usersService;
        }


        /// <summary>
        /// used to authenticate user and returns user access token and route details
        /// </summary>
        /// <param name="credentials">object contains user name and password</param>
        /// <remarks> 
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("authenticateUserDetails")]
        [RequireAuthorization]
        public IActionResult AuthenticateUserDetails(AuthenticationDto credentials) {
            var user = _userService.AuthorizeUserDetails(credentials.UserName, credentials.Password);

            return JsonExt(user);
        }

    }
}
