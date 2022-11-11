using Core.Common.Data;

namespace Core.Business.Entites.DataModels {
    [Alias(Name = "DoctorHospitalRef")]
    public class DoctorHospitalRef {
        public DoctorHospitalRef() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int DoctorUserId { get; set; }
        public bool IsPersonalClinic { get; set; }

    }
}
