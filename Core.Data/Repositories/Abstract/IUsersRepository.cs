using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;

namespace Core.Data.Repositories.Abstract {
    public interface IUsersRepository {
        IEnumerable<Users> GetUsersAuthenticatioByUserName(string userName);
        void UpdateLastlogin(long id);
        IEnumerable<Users> GateUsersDetailsByToken(string accessToken);
        IEnumerable<Users> GateUsersInfoById(int id);
        bool InsertUser(RequestUser ob);
    }
}
