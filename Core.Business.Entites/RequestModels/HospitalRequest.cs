namespace Core.Business.Entites.RequestModels
{
    public class HospitalRequest {
        public int CountryId { get; set; }
        public List<string>? CityList { get; set; }
        public List<string>? HospitalList { get; set; }
        public int LanguageId { get; set; }
    }
}
