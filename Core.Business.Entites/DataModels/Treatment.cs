namespace Core.Business.Entites.DataModels {
    public class Treatment {
        public Treatment() { }
        public int Id { get; set; }
        public int SpecialityId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int LanguageId { get; set; }

    }
}
