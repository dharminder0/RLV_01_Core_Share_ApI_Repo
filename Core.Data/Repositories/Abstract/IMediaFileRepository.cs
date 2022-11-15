using Core.Business.Entites;
using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;
using Core.Common.Contracts;

namespace Core.Data.Repositories.Abstract {
    public interface IMediaFileRepository : IDataRepository<MediaFile> {
        IEnumerable<MediaFile> GetMediaFile();
        IEnumerable<MediaFile> GetEntityMediaFile(int objectId, EntityType entityTypeId);
        //IEnumerable<MediaFile> MediaFileRequest(int objectId);
        bool InsertInMediaFile(MediaFileRequest requestMediaFile);
    }
}

