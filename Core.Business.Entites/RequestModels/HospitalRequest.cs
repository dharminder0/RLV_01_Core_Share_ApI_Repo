using System.Diagnostics.CodeAnalysis;

namespace Core.Business.Entites.RequestModels
{
    public class HospitalRequest {
        //[AllowNull]
        public string SearchText { get; set; } = "";
        public string CountryCode { get; set; }
        public List<string>? CityList { get; set; }
        public List<int>? HospitalList { get; set; }
        public int LanguageId { get; set; } = 1;
    }
}
