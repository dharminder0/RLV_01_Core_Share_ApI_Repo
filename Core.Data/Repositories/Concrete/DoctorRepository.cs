﻿using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Common.Contracts;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Slapper.AutoMapper;

namespace Core.Data.Repositories.Concrete
{
    public class DoctorRepository: DataRepository<Doctor>,IDoctorRepository
    {
        public IEnumerable<Doctor> GetDoctors()
        {
            var sql = $@"SELECT * FROM Doctor ";
            return Query<Doctor>(sql);
        }
        public IEnumerable<Doctor> GetDoctorById( int id)
        {
            var sql = $@"SELECT * FROM Doctor WHERE Id=@id";
            return Query<Doctor>(sql, new { id });
        }
        public IEnumerable<Doctor> GetDoctor(DoctorRequest doctorRequest)
        {
            var sqlQuery = $@"select d.* from doctor d join users U on 
                d.userid = U.id ";

            if (doctorRequest.HospitalList != null && doctorRequest.HospitalList.Any())
            {
                sqlQuery += " JOin [DoctorHospitalRef] DHF on DHF.DoctorUserid = d.userId ";
            }

            sqlQuery += " where usertype =3  and countryId=@CountryId and languageid = @LanguageId ";

            if (!string.IsNullOrWhiteSpace(doctorRequest.SearchText))
            {
                sqlQuery += $@"and DisplayName like '%{doctorRequest.SearchText}%'  ";
            }

            if (doctorRequest.CityList != null && doctorRequest.CityList.Any())
            {
                sqlQuery += " and cityId in @CityList ";
            }
            
            if (doctorRequest.HospitalList != null && doctorRequest.HospitalList.Any())
            {
                sqlQuery += " and DHF.HospitalId in @HospitalList ";
            }

            return Query<Doctor>(sqlQuery, doctorRequest);
        }

    }
}
