using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Common.Caching;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {

    public class HospitalRepository : DataRepository<Hospital>, IHospitalRepository {
        public IEnumerable<Hospital> GetHospitals() {
            var sql = $@"SELECT * FROM Hospital ";
            return Query<Hospital>(sql);
        }
        public IEnumerable<Hospital> GetHospitals(HospitalRequest hospitalRequest) {
            var sqlQuery = $@"SELECT TOP 10 * FROM Hospital ";


            sqlQuery += " where  countryId=@CountryId and languageid = @LanguageId ";


            if (!string.IsNullOrWhiteSpace(hospitalRequest.SearchText)) {

                sqlQuery += $@"and title like '%{hospitalRequest.SearchText}%'  ";
            }


            if (hospitalRequest.CityList != null && hospitalRequest.CityList.Any()) {
                sqlQuery += " and cityId in @CityList ";
            }


            if (hospitalRequest.HospitalList != null && hospitalRequest.HospitalList.Any()) {
                sqlQuery += " and hospital.id in @HospitalList ";
            }

            return Query<Hospital>(sqlQuery, new {
                hospitalRequest.CountryId,
                hospitalRequest.SearchText,
                hospitalRequest.CityList,
                hospitalRequest.HospitalList,
                hospitalRequest.LanguageId
            });
        }

        public Hospital GetHospitalById(int id) {
            var sql = $@"SELECT * FROM Hospital WHERE Id = @id";
            return QueryFirst<Hospital>(sql, new { id });
        }


        public HospitalDetails GetAllHospitalMediaDetails(int id) {
            var sqlQuery = $@"select dc.displayname,dc.designation,dc.id,dc.qualification,dc.experience,dc.details,dc.languageid,mm.Filename 
               ,mm.mediadetails ,mm.updatedby,mm.updatedon  from doctor dc  join MediaFile mm   on
                dc.userid = mm.EntityId  where dc.id = @id";
            return QueryFirst<HospitalDetails>(sqlQuery, new { id });
        }
    }
}

