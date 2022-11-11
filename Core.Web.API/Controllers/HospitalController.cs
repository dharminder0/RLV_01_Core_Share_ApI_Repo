﻿using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Entites.ResponseModels;
using Core.Business.Services.Abstract;
using Core.Business.Services.Concrete;
using Core.Data.Repositories.Concrete;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/Hospital")]
    [ApiController]
    public class HospitalController : BaseApiController {

        private readonly IHospitalService _hospitalService;
        private readonly ICityService _CityService;

        public HospitalController(IHospitalService hospitalService, ICityService CityService) {
            _hospitalService = hospitalService;
            _CityService = CityService;
        }

        /// <summary>
        /// Insert/update for Hospital  
        /// </summary>
        /// <param name="requestHospital"></param>  
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        [RequireAuthorization]
        public IActionResult CreateHospital(RequestHospital requestHospital) {
            var response = _hospitalService.CreateHospital(requestHospital);
            return JsonExt(response);
        }

        /// <summary>
        /// Get Hospital by details 
        /// <param name="requestModel"></param>       
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("List")]
        [RequireAuthorization]
        public IActionResult Hospitals(HospitalRequest requestModel) {
            var response = _hospitalService.GetHospital(requestModel);
            return JsonExt(response);
        }


        /// <summary>
        /// Get Hospitals by Id
        /// <param name="id"></param> 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Id")]
        [RequireAuthorization]
        public HospitalDetails GetHospitalById(int id) {
            return _hospitalService.HospitalDetails(id);
        }


        /// <summary>
        /// Get Hospitals list
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Route("list")]
        //[RequireAuthorization]
        //public List<Hospital> Hospitals() {

            //return _hospitalService.GetHospital();
        

    }
}
