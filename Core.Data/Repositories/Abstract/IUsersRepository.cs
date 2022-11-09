using Core.Business.Entites.DataModels;

namespace Core.Data.Repositories.Abstract {
    public interface IUsersRepository {
        IEnumerable<Users> GetUsersAuthenticatioByUserName(string userName);
        void UpdateUsersAuthentication(long id);
        IEnumerable<Users> GateUsersAuthenticationByToken(string accessToken);
        IEnumerable<Users> GateUsersInfoById(int id);
    }
}
