using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {
    public class UsersRepository : DataRepository<Users>, IUsersRepository {

        public IEnumerable<Users> GetUsersAuthentication(string userName) {
            var sql = $@"SELECT TOP 10 * FROM Users WHERE UserName = @userName";
            return Query<Users>(sql, new { userName });
        }

        public void UpdateUsersAuthentication(long id) {
            var sql = $@"update Users  set  LastLoginDate = GETDATE()  where Id = @id";
            Execute(sql, new { id });
        }

    }
}
