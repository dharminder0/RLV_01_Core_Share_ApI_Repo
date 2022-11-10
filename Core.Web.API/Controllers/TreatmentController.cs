using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/Treatment")]
    [ApiController]
    public class TreatmentController : BaseApiController {
        private readonly ITreatmentService _treatmentService;
        public TreatmentController(ITreatmentService treatmentService) {
            _treatmentService = treatmentService;   

        }

        /// <summary>
        /// used to get Treatment details by countryId .
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// </remarks>
        [HttpGet]
        [Route("infoById/{id}")]
        [RequireAuthorization]
        public IActionResult UsersInfoById(int id) {
            var response = _treatmentService.TreatmentInfoById(id);
            return JsonExt(response);
        }
    }
}
