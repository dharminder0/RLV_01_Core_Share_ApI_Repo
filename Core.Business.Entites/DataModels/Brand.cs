using Core.Common.Data;

namespace Core.Business.Entites.DataModels {
    [Alias(Name = "Brand")]
    public class Brand {
        public Brand() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; }
        public string LanguageId { get; set; }
    }
}
