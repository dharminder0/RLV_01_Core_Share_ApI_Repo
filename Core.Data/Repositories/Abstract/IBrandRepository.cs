using Core.Business.Entites.DataModels;
using Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Abstract {
    public interface IBrandRepository :IDataRepository<Brand>{
        IEnumerable<Brand> GetBrand();
    }
}
