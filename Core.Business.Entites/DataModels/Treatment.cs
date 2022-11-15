using Core.Common.Data;

namespace Core.Business.Entites.DataModels {
    [Alias(Name = "Treatment")]
    public class Treatment {
        public Treatment() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public int SpecialityId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int LanguageId { get; set; }

    }
}
