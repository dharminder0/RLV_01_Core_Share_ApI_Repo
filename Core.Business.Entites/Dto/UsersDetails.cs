using Core.Business.Entites.DataModels;

namespace Core.Business.Entites.Dto {
    public class UsersDetails {
        public Users Users{ get; set; }
        public List<MediaFileDto> Images { get; set; }
    }
}