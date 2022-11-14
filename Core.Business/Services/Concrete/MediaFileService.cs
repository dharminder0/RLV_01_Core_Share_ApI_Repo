using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;

namespace Core.Business.Services.Concrete {
    public class MediaFileService : IMediaFileService {

        private readonly IMediaFileRepository _MediaFileRepository;
        private readonly IMediaFileRepository mediaFileRequest;
        public MediaFileService(IMediaFileRepository MediaFileRepository) {
            _MediaFileRepository = MediaFileRepository;
        }

        public List<MediaFile> GetMediaFile() {

            return _MediaFileRepository.GetMediaFile().ToList();
        }

        public  bool CreateMediaFile(MediaFileRequest requestMediaFile) {

            return _MediaFileRepository.InsertInMediaFile(requestMediaFile);
        }
    }
}
