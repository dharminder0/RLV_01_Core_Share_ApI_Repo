using Core.Business.Entites.DataModels;

namespace Core.Business.Entites.Dto {
    public class HospitalDetails {
        public Hospital Hospital { get; set; }
        public List<MediaFileDto> Images { get; set; }
    }
}
