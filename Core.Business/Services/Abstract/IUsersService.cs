using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;

namespace Core.Business.Services.Abstract {
    public interface IUsersService {
        UserDto AuthenticateUser(string userName, string password);
        Object AuthorizeUserDetails(string userName, string password);
        //UserInfo GetUserInfo(string userToken = "", string clientCode = "", Users userObj = null);
        //UserInfo GetUserInfoCached(string userToken = "", string clientCode = null, Users userObj = null);
    }
}
