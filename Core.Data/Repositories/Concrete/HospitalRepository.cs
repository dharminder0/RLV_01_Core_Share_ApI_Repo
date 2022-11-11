﻿using Core.Business.Entites.DataModels;
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

            if (hospitalRequest.CountryCode != null && hospitalRequest.CountryCode.Any( ))
            {
                sqlQuery += " JOin [Country] C on C.Id = Hospital.CountryId ";

            }
            if (hospitalRequest.CityList != null && hospitalRequest.CityList.Any())
            {
                sqlQuery += " JOin [City] Ct on Ct.CountryId = C.id ";
                
            }
            sqlQuery += " where  languageid = @LanguageId ";



            if (!string.IsNullOrWhiteSpace(hospitalRequest.SearchText)) {

                sqlQuery += $@"and Title like '%{hospitalRequest.SearchText}%'  ";
            }

           


            if (hospitalRequest.CityList != null && hospitalRequest.CityList.Any()) {
                sqlQuery += "and CityName in @CityList ";
            }


            if (hospitalRequest.HospitalList != null && hospitalRequest.HospitalList.Any()) {
                sqlQuery += " and hospital.id in @HospitalList ";
            }
            if (hospitalRequest.CountryCode != null)
            {
                sqlQuery += " and C.code = @CountryCode";

            }


            return Query<Hospital>(sqlQuery, new {
                hospitalRequest.CountryCode,
                hospitalRequest.SearchText,
                hospitalRequest.CityList,
                hospitalRequest.HospitalList,
                hospitalRequest.LanguageId
            });
        }

        public IEnumerable<Hospital> GetHospitalById(int id) {
            var sql = $@"SELECT * FROM hospital WHERE Id = @id";
            return Query<Hospital>(sql, new { id });
        }
    }
}


