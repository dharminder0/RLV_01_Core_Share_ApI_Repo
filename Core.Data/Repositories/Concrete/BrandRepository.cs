using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {
    public class BrandRepository : DataRepository<Brand>, IBrandRepository {
        public IEnumerable<Brand> GetBrand() {
            var sql = $@"SELECT * FROM Brand ";
            return Query<Brand>(sql);

        }
        public IEnumerable<Brand> GetBrandById(int BrandId) {
            var sql = $@"SELECT * FROM  Brand where Id=@BrandId";
            return Query<Brand>(sql, new { BrandId });
        }
    }
}



