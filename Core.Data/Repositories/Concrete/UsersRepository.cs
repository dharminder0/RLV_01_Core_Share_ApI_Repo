using Azure.Core;
using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {
    public class UsersRepository : DataRepository<Users>, IUsersRepository {

        public IEnumerable<Users> GetUsersAuthenticatioByUserName(string userName) {
            var sql = $@"SELECT TOP 10 * FROM Users WHERE UserName = @userName";
            return Query<Users>(sql, new { userName });
        }

        public void UpdateUsersAuthentication(long id) {
            var sql = $@"update Users  set  LastLoginDate = GETDATE()  where Id = @id";
            Execute(sql, new { id });
        }
        public IEnumerable<Users> GateUsersAuthenticationByToken(string accessToken) {
            var sql = $@"SELECT TOP 10 * FROM Users WHERE Token = @accessToken";
            return Query<Users>(sql, new { accessToken });
        }
        public IEnumerable<Users> GateUsersInfoById(int id) {
            var sql = $@"SELECT TOP 10 * FROM Users WHERE id = @id";
            return Query<Users>(sql, new { id });
        }

    }
}
