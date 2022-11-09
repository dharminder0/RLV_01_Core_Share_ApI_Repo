using Core.Business.Entites.DataModels;

namespace Core.Business.Entites.Dto {
    public class HospitalDetails {
        public List<MediaFileDto> Image;

        public List<MediaFile> image { get; set;}
        public List<MediaFileDto> Images { get; set; }
    }
}
