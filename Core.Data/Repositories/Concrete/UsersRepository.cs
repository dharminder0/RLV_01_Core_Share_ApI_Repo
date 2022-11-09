using Azure.Core;
using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {
    public class UsersRepository : DataRepository<Users>, IUsersRepository {

        public IEnumerable<Users> GetUsersAuthenticatioByUserName(string userName) {
            var sql = $@"SELECT TOP 10 * FROM Users WHERE UserName = @userName";
            return Query<Users>(sql, new { userName });
        }

        public void UpdateLastlogin(long id) {
            var sql = $@"update Users  set  LastLoginDate = GETDATE()  where Id = @id";
            Execute(sql, new { id });
        }
        public IEnumerable<Users> GateUsersDetailsByToken(string accessToken) {
            var sql = $@"SELECT TOP 10 * FROM Users WHERE Token = @accessToken";
            return Query<Users>(sql, new { accessToken });
        }
        public IEnumerable<Users> GateUsersInfoById(int id) {
            var sql = $@"SELECT TOP 10 * FROM Users WHERE id = @id";
            return Query<Users>(sql, new { id });
        }

        public bool InsertUser(RequstUsers ob) {
            var sql = @"IF NOT EXISTS(SELECT 1 from Users where UserName = @UserName)
BEGIN
INSERT INTO Users
           (FirstName
           ,LastName
           ,UserName
           ,Token
           ,Email
           ,Phone
           ,CountryId
           ,CityId
           ,PostalCode
           ,Address1
           ,Address2
           ,UserType)
     VALUES
           (@FirstName
           ,@LastName
           ,@UserName
           ,@Token
           ,@Email
           ,@Phone
           ,@CountryId
           ,@CityId
           ,@PostalCode
           ,@Address1
           ,@Address2
           ,@UserType)
END
ELSE
BEGIN
UPDATE Users SET FirstName = @FirstName,LastName = @LastName, UserName = @UserName
Where Id = @Id and UserName = @UserName;
END";
            return Execute(sql, ob) > 0;
        }

    }
}
