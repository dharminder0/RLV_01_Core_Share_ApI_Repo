using Core.Common.Data;

namespace Core.Business.Entites.DataModels {
    [Alias(Name = "HospitalSpecialityRef")]
    public class HospitalSpecialityRef {
        public HospitalSpecialityRef() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int SpecialityId { get; set; }
    }
}
