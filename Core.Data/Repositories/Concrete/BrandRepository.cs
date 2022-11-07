using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Concrete {
    public class BrandRepository  : DataRepository<Brand>, IBrandRepository {
        public IEnumerable<Brand> GetBrand() {
            var sql = $@"SELECT * FROM Brand ";
            return Query<Brand>(sql);
        }
    }
}

   