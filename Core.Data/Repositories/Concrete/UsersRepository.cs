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

        public bool InsertUser(RequestUser ob) {
            var sql = @"IF NOT EXISTS(SELECT 1 from Users where UserName = @UserName)
BEGIN
INSERT INTO Users
           (
              FirstName
             ,LastName
             ,UserName
             ,Password
             ,Token
             ,Email
             ,Phone
             ,CountryId
             ,CityId
             ,PostalCode
             ,Address1
             ,Address2
             ,LastLoginDate
             ,UserType
             ,IsVerified
             ,IsActive
            )
     VALUES
           (
             @FirstName
            ,@LastName
            ,@UserName
            ,@Password
            ,@Token
            ,@Email
            ,@Phone
            ,@CountryId
            ,@CityId
            ,@PostalCode
            ,@Address1
            ,@Address2
            ,@LastLoginDate
            ,@UserType
            ,@IsVerified
            ,@IsActive
            )
END
ELSE
BEGIN
UPDATE Users SET   FirstName = @FirstName
             ,LastName = @LastName
             ,Password = @Password
             ,Token = @Token
             ,Email = @Email
             ,Phone = @Phone
             ,CountryId = @CountryId
             ,CityId = @CityId
             ,PostalCode = @PostalCode
             ,Address1 = @Address1
             ,Address2 = @Address2
             ,LastLoginDate = @LastLoginDate 
             ,UserType = @UserType
             ,IsVerified = @IsVerified
             ,IsActive = @IsActive
Where  UserName = @UserName;
END
";
            return Execute(sql, new {
                FirstName = ob.FirstName,
                LastName = ob.LastName,
                UserName = ob.UserName,
                Password = ob.Password,
                Token = ob.Token,
                Email = ob.Email,
                Phone = ob.Phone,
                CountryId = ob.CountryId,
                CityId = ob.CityId,
                PostalCode = ob.PostalCode,
                Address1 = ob.Address1,
                Address2 = ob.Address2,
                LastLoginDate = ob.LastLoginDate,
                UserType = ob.UserType,
                IsVerified = ob.IsVerified,
                IsActive = ob.IsActive
            }) > 0;
        }

    }
}
