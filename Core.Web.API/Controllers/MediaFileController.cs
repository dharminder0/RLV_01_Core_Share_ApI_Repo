using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;
using Core.Business.Services.Abstract;
using Core.Business.Services.Concrete;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MediaFileController : BaseApiController {
        private readonly IMediaFileService _MediaFileService;

        public MediaFileController(IMediaFileService MediaFileService) {
            _MediaFileService = MediaFileService;
        }

        /// <summary>
        /// Get Media Details
        /// </summary>
        [HttpGet]
        [Route("GetMediaFileList")]
        [RequireAuthorization]
        public List<MediaFile> GetMediaFile() {

            return _MediaFileService.GetMediaFile();
        }

        [HttpPost]
        [Route("addImage")]
        [RequireAuthorization]
        public IActionResult CreateMediaFile(MediaFileRequest requestMediaFile) {
            var response = _MediaFileService.CreateMediaFile(requestMediaFile);
            return JsonExt(response);
        }
    }
}


