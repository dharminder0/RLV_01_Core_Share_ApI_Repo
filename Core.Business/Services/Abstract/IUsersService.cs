using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;

namespace Core.Business.Services.Abstract {
    public interface IUsersService {
        UserDto AuthenticateUser(string userName, string password);
        Object AuthorizeUserDetails(string userName, string password);
        UserDto GetUserByAccessToken(string accessToken);
        object UsersInfoById(int id);
    }
}
