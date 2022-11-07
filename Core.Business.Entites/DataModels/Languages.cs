using Core.Common.Data;

namespace Core.Business.Entites.DataModels
{
    [Alias(Name = "Languages")]
    public class Languages
    {
        public Languages() {}
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
    }
}
