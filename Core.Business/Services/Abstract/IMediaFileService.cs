using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;

namespace Core.Business.Services.Abstract {
    public interface IMediaFileService {
        List<MediaFile> GetMediaFile();
        bool CreateMediaFile(MediaFileRequest requestMediaFile);

    }
}
