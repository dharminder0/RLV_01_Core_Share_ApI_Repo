using Core.Common.Data;

namespace Core.Business.Entites.DataModels
{
    [Alias(Name = "City")]
    public class City
    {
        public City() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }      
    }
}
