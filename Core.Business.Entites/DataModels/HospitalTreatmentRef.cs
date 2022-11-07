namespace Core.Business.Entites.DataModels {
    public class HospitalTreatmentRef {
        public HospitalTreatmentRef() { }
        public  int Id { get; set; }
        public int HospitalId { get; set; }
        public int TreatmentId { get; set; }
        public decimal TreatmentAmount { get; set; }

    }
}
