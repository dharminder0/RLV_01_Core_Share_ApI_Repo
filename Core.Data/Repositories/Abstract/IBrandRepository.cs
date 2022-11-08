using Core.Business.Entites.DataModels;
using Core.Common.Contracts;

namespace Core.Data.Repositories.Abstract {
    public interface IBrandRepository :IDataRepository<Brand>{
        IEnumerable<Brand> GetBrand();
        IEnumerable<Brand>  GetBrandById(int id);
    }
}