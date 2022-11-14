using Core.Business.Entites.ResponseModels;
using Core.Business.Entites.Utils;
using Core.Business.Services.Concrete;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Core.Web.API.Controllers {
    [Route("api/Blob")]
    [ApiController]
    public class BlobController : BaseApiController {

        private readonly BlobStorageService _blobStorageService = new BlobStorageService();

        public BlobController() { }


        #region Blob Storage

        /// <summary>
        /// Upload File Attachment
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Blob/UploadFile")]
        [RequireAuthorization]
        public async Task<IActionResult> UploadFile() {
            try {

                FileUpload response = null;
                var formCollection = await Request.ReadFormAsync();
                var fileList = formCollection.Files;

                if (fileList != null) {
                    foreach (var item in fileList) {
                        using (var memoryStream = new MemoryStream()) {
                            await item.CopyToAsync(memoryStream);
                            var fileBytes = memoryStream.ToArray();

                            if (fileBytes != null) {
                                var fileName = item.FileName.Trim('\"');
                                fileName = fileName.Replace(" ", "").Replace("-", "");
                                response = _blobStorageService.UploadFileToBlob(fileName, fileBytes);
                            }
                        }
                    }
                }

                if (response != null) {
                    var serializer = new JsonSerializer { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                    var json = JObject.FromObject(response, serializer);
                    return JsonExt(new { data = json, message = "Upload success" });
                } else {
                    return JsonExt(new { data = (FileUpload)null, message = "Upload failed" });
                }
            } catch (Exception ex) {
                // return BadRequest();
                return JsonExt(new { data = (string)null, message = ex.ExtractInnerException() });
            }
        }

        /// <summary>
        /// Get File Link
        /// </summary>
        /// <param name="fileIdentifier"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Blob/GetFileLink")]
        [RequireAuthorization]
        public string GetFileLink(string fileIdentifier) {
            var response = _blobStorageService.GetBlobLinkByFileIdentifier(fileIdentifier);
            return response;
        }

        #endregion

    }
}
