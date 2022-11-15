using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Concrete {
    public class SpecialityRepository : DataRepository<Speciality>, ISpecialityRepository {
        public IEnumerable<Speciality> GetSpecialityInfo(string countryCode) {
            var sql = $@"select * from Speciality where LanguageId = @countryCode";
            return Query<Speciality>(sql, new { countryCode });
        }
    }
}
