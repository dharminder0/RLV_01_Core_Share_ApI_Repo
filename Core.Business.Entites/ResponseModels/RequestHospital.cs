namespace Core.Business.Entites.ResponseModels {
    public class RequestHospital {
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string AdditionalDetails { get; set; }
        public string Infrastructure { get; set; }
        public string Address { get; set; }
        public int BedCount { get; set; }
        public int LanguageId { get; set; }
        public int BrandId { get; set; }
        public int Rank { get; set; }
    }
   
    public class RequestHospitalTreatment {
        public int HospitalId { get; set; }
        public int TreatmentId { get; set; }

    }
}

