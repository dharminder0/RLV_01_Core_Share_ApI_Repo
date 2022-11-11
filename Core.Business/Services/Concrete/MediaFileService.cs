using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;

namespace Core.Business.Services.Concrete {
    public class MediaFileService : IMediaFileService {

        private readonly IMediaFileRepository _MediaFileRepository;
        public MediaFileService(IMediaFileRepository MediaFileRepository) {
            _MediaFileRepository = MediaFileRepository;
        }

        public List<MediaFile> GetMediaFile() {

            return _MediaFileRepository.GetMediaFile().ToList();
        }
    }
}
