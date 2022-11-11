using Core.Business.Entites.DataModels;

namespace Core.Business.Services.Abstract {
    public interface IBrandService {
        List<Brand> GetBrand();
        List<Brand> GetBrandById(int id);
    }
}
