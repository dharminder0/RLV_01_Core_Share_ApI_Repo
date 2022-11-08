using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Web.Api.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.API.Controllers {
    [Route("api/Brand")]
    [ApiController]
    public class BrandController : BaseApiController {
        
        private readonly IBrandService _BrandService;

        public BrandController(IBrandService brandService) {
            _BrandService = brandService;
        }

        [HttpGet]
        [Route("list")]
        [RequireAuthorization]
        public List<Brand> GetBrand() {

            return _BrandService.GetBrand();
        }

        [HttpGet]
        [Route("Id")]
        [RequireAuthorization]
        public List<Brand> GetBrandById(int id) {

            return _BrandService.GetBrandById(id);
        }
    }
}

