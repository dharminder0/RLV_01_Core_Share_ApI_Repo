using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {
    public class TreatmentRepository : DataRepository<Treatment>, ITreatmentRepository {
        public IEnumerable<Treatment> GetTreatmentInfoById(string countryCode) {
            var sql = $@"select * from Treatment where LanguageId = @countryCode";
            return Query<Treatment>(sql, new { countryCode });
        }
        public IEnumerable<Treatment> TreatmentInfoBySpecialityId(int specialityId) {
            var sql = $@"select * from Treatment where SpecialityId = @SpecialityId";
            return Query<Treatment>(sql, new { specialityId });
        } 
        
        public IEnumerable<Treatment> TreatmentInfo() {
            var sql = $@"select  * from Treatment ";
            return Query<Treatment>(sql);
        }
    }
}
