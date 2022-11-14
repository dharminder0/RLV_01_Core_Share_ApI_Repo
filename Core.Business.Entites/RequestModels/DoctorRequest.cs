﻿namespace Core.Business.Entites.RequestModels {
    public class DoctorRequest {
        public string SearchText { get; set; } = "";
        public string CountryCode { get; set; }
        public List<int>? CityList { get; set; } 
        public List<int>? HospitalList { get; set; } 
        public int LanguageId { get; set; } = 1;
        public  List<int> ? YearExperience { get; set; }
        public List<int>? specialityId { get; set; }

    }
}
