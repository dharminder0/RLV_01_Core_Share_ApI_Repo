using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Abstract {
    public interface IMediaFileRepository : IDataRepository<MediaFile>{
        IEnumerable<MediaFile> GetMediaFile();
    }
}

