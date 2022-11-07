namespace Core.Business.Entites.DataModels {
    public class UserBrandRef {
        public UserBrandRef() { }
        public int Id { get; set; }
        public int UserId { get; set; }    
        public int BrandId { get; set; }    
        public bool IsActive { get; set; }

    }
}
