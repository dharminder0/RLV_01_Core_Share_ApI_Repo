using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;
using Core.Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Services.Concrete {
    public class BrandService : IBrandService {

        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository) {
            _brandRepository = brandRepository; }

        public List<Brand> GetBrand() {

            return _brandRepository.GetBrand().ToList();
        }
    }
}
