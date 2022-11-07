namespace Core.Business.Entites.DataModels {
    public class DoctorSpecialityRef {
        public DoctorSpecialityRef() { }
        public int Id { get; set; }
        public int SpecilityId { get; set; }
        public int DoctorId { get; set; }

        public string Details { get; set; }

        public string Symbol { get; set; }

        public decimal TreatmentAmount { get; set; }
        public int  TreatmentId { get; set; }


}
}
