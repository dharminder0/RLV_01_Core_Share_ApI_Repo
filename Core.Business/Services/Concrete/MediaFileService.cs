using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Business.Services.Concrete.MediaFileService;

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
