using Core.Business.Entites;
using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {
    public class MediaFileRepository : DataRepository<MediaFile>, IMediaFileRepository {
        public IEnumerable<MediaFile> GetMediaFile() {
            var sql = $@"SELECT * FROM MediaFile ";
            return Query<MediaFile>(sql);
        }

        public IEnumerable<MediaFile> GetEntityMediaFile(int objectId, EntityType entityTypeId) {
            var sql = $@"SELECT * FROM MediaFile where EntityId = @objectId and  EntityTypeId = @entityTypeId";
            return Query<MediaFile>(sql, new { objectId, entityTypeId });
        }

    }
}
