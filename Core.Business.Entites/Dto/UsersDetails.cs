using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;

namespace Core.Business.Entites.Dto {
    public class UsersDetails {
        public UserBasicDto Users { get; set; }
        public List<MediaFileDto> Images { get; set; }
    }
}