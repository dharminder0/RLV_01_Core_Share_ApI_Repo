namespace Core.Business.Entites.RequestModels
{
    public class HospitalRequest
    {
        //[AllowNull]
        public string SearchText { get; set; } = "";
        public string CountryCode { get; set; } = "IN";
        public List<int>? CityList { get; set; }
        public List<int>? HospitalList { get; set; }
        public int LanguageId { get; set; } = 1;
        public List<int>? EstablishedYear { get; set; }
        public List<int>? BedCount { get; set; }
        public List<int>? SpecialityId { get; set; }
        public List<int>? TreatmentIds { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
    //    public class EstablishedYear
    //    {
    //        public int MinValue { get; set; } = 1980;
    //        public int MaxValue { get; set; } = 2000;

    //    }
}
//}