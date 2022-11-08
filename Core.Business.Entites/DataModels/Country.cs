using Core.Common.Data;

namespace Core.Business.Entites.DataModels {
    [Alias(Name = "Country")]
    public class Country {
        public Country () { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string CountryName { get; set; }
    }
}
