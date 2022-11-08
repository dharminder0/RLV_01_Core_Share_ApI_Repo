using System.Diagnostics.CodeAnalysis;

namespace Core.Business.Entites.RequestModels
{
    public class HospitalRequest {
        //[AllowNull]
        public string SearchText { get; set; }
        public int CountryId { get; set; }
        public List<int> CityList { get; set; }
        public List<int> HospitalList { get; set; }
        public int LanguageId { get; set; } = 1;
    }
}
