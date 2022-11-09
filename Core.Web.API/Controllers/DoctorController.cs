using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Concrete;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [Route("{id}")]
        [RequireAuthorization]
        public DoctorDetails GetDoctorsById(int id)
        {
            return _doctorService.DoctorDetails(id);
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
