using Core.Common.Data;

namespace Core.Business.Entites.DataModels
{
    [Alias(Name = "Users")]
    public  class Users
    {
        public Users() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? CountryId  { get; set; }
        public int? CityId { get; set; }
        public string PostalCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int UserType { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }

    }
}
