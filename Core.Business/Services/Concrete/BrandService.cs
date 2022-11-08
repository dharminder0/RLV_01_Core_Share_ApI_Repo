using Core.Business.Entites.DataModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;

namespace Core.Business.Services.Concrete {
    public class BrandService : IBrandService {

        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository) {
            _brandRepository = brandRepository; }

        public List<Brand> GetBrand() {

            return _brandRepository.GetBrand().ToList();
        }
        public List<Brand> GetBrandById(int id) {
            return _brandRepository.GetBrandById(id).ToList();
        }
}
    }
