using Core.Common.Data;
namespace Core.Business.Entites.DataModels
{
    public class Speciality
    {
        public Speciality() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int? LanguageId { get; set; }

    }
}
