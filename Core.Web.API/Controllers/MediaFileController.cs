using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Http;
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
    }
}
    

