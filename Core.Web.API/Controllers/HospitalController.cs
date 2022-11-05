using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : BaseApiController {

        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService) {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        [Route("list")]
        public List<Hospital> Hospitals() {

            return _hospitalService.GetHospitals();
        }
    }
}
