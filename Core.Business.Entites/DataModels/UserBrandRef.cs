using Core.Common.Data;

namespace Core.Business.Entites.DataModels {
    [Alias(Name = "UserBrandRef")]
    public class UserBrandRef {
        public UserBrandRef() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BrandId { get; set; }
        public bool IsActive { get; set; }

    }
}
