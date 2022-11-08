using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Concrete {
    public class UsersRepository : DataRepository<Users>, IUsersRepository {

        public IEnumerable<Users> GetUsersAuthentication(string userName) {
            var sql = $@"SELECT TOP 10 * FROM Users WHERE UserName = @userName";
            return Query<Users>(sql, new { userName });
        }

        //public bool GetUsersAuthentication(string userName, string password) {
        //    var sql = $@"SELECT  * FROM Users WHERE UserName = @userName and Password = @password";
        //    return Execute(sql, new { userName, password }) > 0;
        //}

    }
}
