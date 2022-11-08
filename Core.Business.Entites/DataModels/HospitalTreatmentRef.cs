using Core.Common.Data;

namespace Core.Business.Entites.DataModels {
    [Alias(Name = "HospitalTreatmentRef")]
    public class HospitalTreatmentRef {
        public HospitalTreatmentRef() { }
        [Key(AutoNumber = true)]
        public  int Id { get; set; }
        public int HospitalId { get; set; }
        public int TreatmentId { get; set; }
        public decimal TreatmentAmount { get; set; }

    }
}
