using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Concrete;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;


namespace Core.Web.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : BaseApiController {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
                
        }

        [HttpGet]
        [Route("id")]
        [RequireAuthorization]
        public List<Doctor> GetDoctorsById(int Id)
        {
           return _doctorService.GetDoctorDetailsById(Id);
        }


        [HttpPost]
        [Route("list")]
        [RequireAuthorization]
        public IActionResult Doctors(DoctorRequest requestModel)
        {
            var response = _doctorService.GetDoctor(requestModel);
            return JsonExt(response);
        }

    }
}
