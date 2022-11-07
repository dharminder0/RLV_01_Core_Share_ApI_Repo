using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        public UserController()
        {

        }

        /// <summary>
        /// Validates the user encrypted token passed in header and returns detailed user info
        /// </summary>
        /// <param name="clientCode"></param>
        /// <returns></returns>
        [HttpGet]
        [RequireAuthorization]
        [Route("api/v1/account/get-user-info")]
        public object ValidateJwtToken(string clientCode)
        {
            //var userToken = GetUserTokenFromHeader(_configuration);
            //ThreadPool.QueueUserWorkItem(_cacheService.SetInitialCache, new object[] { clientCode, this.LanguageCode });
            //var info = _userService.GetUserInfo(userToken, clientCode);
            //// separate encrypted token to send as required from API
            //var token = Request.Headers["token"];
            //try
            //{
            //    var userClientsResponse = _accountsExternalService.GetUserClients(clientCode, token);
            //    if (userClientsResponse != null && userClientsResponse.Data.Any())
            //    {
            //        info.UserClients = userClientsResponse.Data.Select(x => new { x.Id, x.ClientCode, x.CompanyName, x.LogoUrl });
            //    }
            //}
            //catch (Exception e)
            //{
            //    info.UserClients = null;
            //}
            //return info;
            return null;
        }
    }
}
