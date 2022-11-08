using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
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
        [Route("GetDoctors")]
        [RequireAuthorization]
        public List<Doctor> GetDoctors() {
            return _doctorService.GetDoctors();
        }

        // GET api/<DoctorController>/5
        [HttpGet]
        [Route("GetDoctorById")]
        [RequireAuthorization]
        public List<Doctor> GetDoctorsById(int Id)
        {
           return _doctorService.GetDoctorDetailsById(Id);
        }

        //// POST api/<DoctorController>
        //[HttpPost]
        ////public List<Doctor> AddDoctorsDeatils( Doctor  doctor)
        ////{
        ////}

        //// PUT api/<DoctorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DoctorController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


    }
}
