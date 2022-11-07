namespace Core.Business.Entites.DataModels {
    public class HospitalSpecialityRef {
        public HospitalSpecialityRef() { }
        public int Id { get; set; }
        public string Title { get; set; }

        public string Details { get; set; }

        public string Symbol { get; set; }

        public int LanguageId { get; set; }
    }
}
