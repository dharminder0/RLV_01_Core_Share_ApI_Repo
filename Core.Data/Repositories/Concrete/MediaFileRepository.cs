using Core.Business.Entites;
using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;
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


        public bool InsertInMediaFile(MediaFileRequest requestMediaFile) {
            var sql = @"IF NOT EXISTS(SELECT 1 from MediaFile where EntityId = @EntityId and  EntityTypeId = @EntityTypeId)
            
BEGIN
INSERT INTO MediaFile	 
		   (
            EntityTypeId,
            EntityId,
            FileName,
            BlobLink,
            LocalPath	
            )
     VALUES(
            @EntityTypeId,
            @EntityId,
            @FileName,
            @BlobLink,
            @LocalPath);               
END
ELSE
BEGIN
UPDATE MediaFile SET EntityTypeId = @EntityTypeId, EntityId = @EntityId, FileName = @FileName, BlobLink = @BlobLink, LocalPath = @LocalPath
Where EntityId = @EntityId and EntityTypeId = @EntityTypeId 
END";
            return Execute(sql, new {
                EntityTypeId = requestMediaFile.EntityTypeId,
                EntityId = requestMediaFile.EntityId,
                FileName = requestMediaFile.FileName,
                BlobLink = requestMediaFile.Bloblink,
                LocalPath = requestMediaFile.LocalPath
            }) > 0;
        }


    }
}
