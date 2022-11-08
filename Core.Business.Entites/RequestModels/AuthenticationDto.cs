using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.RequestModels {
    public class AuthenticationDto {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
