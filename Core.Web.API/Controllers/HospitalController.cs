using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Concrete;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {

    [ApiController]
    public class HospitalController : BaseApiController {

        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService) {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        [Route("api/Hospital/v1list")]
        [RequireAuthorization]
        public List<Hospital> Hospitals() {

            return _hospitalService.GetHospitals();
        }

        /// <summary>
        /// Get Hospitals
        /// <param name="obj"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Hospital/v1/list")]
        [RequireAuthorization]
        public List<Hospital> Hospitals(HospitalRequest hospitalRequest) {

            return _hospitalService.GetHospitals(hospitalRequest);
        }
    }
}
