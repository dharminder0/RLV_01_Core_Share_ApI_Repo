using Core.Business.Entites.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Abstract {
    public interface IUsersRepository {
        IEnumerable<Users> GetUsersAuthenticatioByUserName(string userName);
        void UpdateUsersAuthentication(long id);
        IEnumerable<Users> GateUsersAuthenticationByToken(string accessToken);
    }
}
