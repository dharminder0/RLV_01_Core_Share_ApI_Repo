using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;

namespace Core.Business.Services.Abstract {
    public interface IUsersService {
        UserDto AuthenticateUser(string userName, string password);
        Object Userlogin(string userName, string password);
        UserDto GetUserInfoByToken(string accessToken);
        object UsersInfoById(int id);
        bool CreateUser(RequstUsers ob);
    }
}
