using Core.Business.Entites;
using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;
using Microsoft.Azure.Amqp.Framing;

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

        public bool InsertUser(RequestUsers ob) {
            var sql = @"IF NOT EXISTS(SELECT 1 from Users where UserName = @UserName)
BEGIN
INSERT INTO Users
           (
            FirstName
           ,LastName
           ,UserName
           ,Email
           ,Phone
           ,CountryId
           ,CityId
           ,PostalCode
           ,Address1
           ,Address2
           ,UserType)
     VALUES
           (
            @FirstName
           ,@LastName
           ,@UserName
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
UPDATE Users SET FirstName = @FirstName,LastName = @LastName
Where  UserName = @UserName;
END
";
            return Execute(sql, new {
               // Id = ob.Id,
             FirstName = ob.FirstName
           , LastName = ob.LastName
           , UserName = ob.UserName
           , Email = ob.Email
           , Phone = ob.Phone
           , CountryId = ob.CountryId
           , CityId = ob.CityId
           , PostalCode = ob.PostalCode
           , Address1 = ob.Address1
           , Address2 = ob.Address2
           , UserType = ob.UserType
            }) > 0;
        }

    }
}
