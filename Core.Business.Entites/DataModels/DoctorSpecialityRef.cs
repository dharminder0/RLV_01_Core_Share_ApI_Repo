using Core.Common.Data;

namespace Core.Business.Entites.DataModels {
    [Alias(Name = "DoctorSpecialityRef")]
    public class DoctorSpecialityRef {
        public DoctorSpecialityRef() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public int SpecilityId { get; set; }
        public int DoctorUserId { get; set; }
        public string Details { get; set; }
        public string Symbol { get; set; }
        public decimal TreatmentAmount { get; set; }
        public int TreatmentId { get; set; }
    }
}
