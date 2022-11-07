using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Concrete {
    public class MediaFileRepository : DataRepository<MediaFile>, IMediaFileRepository {
        public IEnumerable<MediaFile>  GetMediaFile() {
            var sql = $@"SELECT * FROM MediaFile ";
            return Query<MediaFile>(sql);
        }
    }
}
