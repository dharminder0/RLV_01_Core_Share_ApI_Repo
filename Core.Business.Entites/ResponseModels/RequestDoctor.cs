namespace Core.Business.Entites.ResponseModels {
    public class RequestDoctor {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public string Details { get; set; }
        public string AdditionalDetails { get; set; }
        public int LanguageId { get; set; }     
        public int Rank { get; set; }
        public int YearExperience { get; set; }
        public int Range { get; set; }
        

    }
}
