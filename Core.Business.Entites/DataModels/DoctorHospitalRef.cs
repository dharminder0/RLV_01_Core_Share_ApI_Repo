namespace Core.Business.Entites.DataModels {
    public class DoctorHospitalRef {
        public DoctorHospitalRef() { }
        public int Id { get; set; }
        public int HospitalId { get; set; }    
        public int DoctorUserId { get; set; }
        public bool IsPersonalClinic { get; set; }

    }
}
