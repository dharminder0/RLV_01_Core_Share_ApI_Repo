using Core.Business.Entites;
using Core.Business.Entites.DataModels;
using Core.Common.Contracts;

namespace Core.Data.Repositories.Abstract {
    public interface IMediaFileRepository : IDataRepository<MediaFile> {
        IEnumerable<MediaFile> GetMediaFile();
        IEnumerable<MediaFile> GetEntityMediaFile(int objectId, EntityType entityTypeId);
    }
}

