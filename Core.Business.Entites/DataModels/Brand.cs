namespace Core.Business.Entites.DataModels {
    public class Brand {
        public Brand() { }
        public int Id { get; set; } 
        public string BrandCode { get; set; }    
        public string BrandName { get; set; }
        public string Color1 { get; set; }
        public string  Color2 { get; set; }
        public int LogoId { get; set; }
        public bool IsActive { get; set; }
    }
}
