using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.ResponseModels {
    public class UserDto {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }     
        public string AuthenticationStatus { get; set; }
          
    }


    public class UserDetails {
        public long Id { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string AuthenticationStatus { get; set; }

    }

    public class UserBasicDto {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string ClientCode { get; set; }
        public DateTime? CreatedOn { get; set; }
    }


}
