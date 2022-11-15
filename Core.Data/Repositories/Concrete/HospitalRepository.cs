using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Entites.ResponseModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;
using Microsoft.Azure.Amqp.Transaction;
using System.Collections.Generic;

namespace Core.Data.Repositories.Concrete {

    public class HospitalRepository : DataRepository<Hospital>, IHospitalRepository {

        public IEnumerable<Hospital> GetHospitals(HospitalRequest hospitalRequest)
        {

            //var sqlQuery = $@"SELECT TOP 10 * FROM Hospital ";
            //var sqlQuery = $@" DECLARE @MinValue AS int ";

            var sqlQuery = $@"SELECT distinct h.Id,h.AdditionalDetails,h.Address,h.BedCount,h.BrandId,h.CountryId,h.Title,h.Rank,h.LanguageId,
                h.Infrastructure,h.EstablishedDate,h.Details,h.CityId,h.BedCount FROM Hospital h ";


            if (hospitalRequest.CountryCode != null && hospitalRequest.CountryCode.Any())
            {
                sqlQuery += " JOin [Country] C on C.Id = h.CountryId ";

            }
          
            if (hospitalRequest.SpecialityId != null && hospitalRequest.SpecialityId.Any())
            {
                sqlQuery += " JOin [HospitalSpecialityRef] hs on hs.HospitalId = h.id ";
               

            }
            if (hospitalRequest.TreatmentIds != null && hospitalRequest.TreatmentIds.Any())
            {
                sqlQuery += " JOin [HospitalTreatmentRef] ht on ht.HospitalId = h.id ";


            }
            sqlQuery += " where  languageid = @LanguageId ";
          



            if (!string.IsNullOrWhiteSpace(hospitalRequest.SearchText))
            {

                sqlQuery += $@"and Title like '%{hospitalRequest.SearchText}%'  ";
            }


            if (hospitalRequest.CityList != null && hospitalRequest.CityList.Any())
            {
                sqlQuery += "and cityid in @CityList ";
            }

            if (hospitalRequest.SpecialityId != null)
            {
                sqlQuery += "and hs.SpecialityId in @SpecialityId";
            }

            if (hospitalRequest.TreatmentIds != null)
            {
                sqlQuery += "and ht.TreatmentId in @TreatmentIds";
            }

            if (hospitalRequest.EstablishedYear != null && hospitalRequest.EstablishedYear.Any())
            {
                int minRange = 0; int maxRange = 0; 
                if (hospitalRequest.EstablishedYear.Count > 1)
                {
                    minRange = hospitalRequest.EstablishedYear[0];
                    maxRange = hospitalRequest.EstablishedYear[1];
                }
                if (minRange >0 && maxRange >0)
                    {
                    sqlQuery += $@" and  h.EstablishedYear between {minRange} and {maxRange} ";
                }
            }


            if (hospitalRequest.HospitalList != null && hospitalRequest.HospitalList.Any())
            {
                sqlQuery += " and h.id in @HospitalList ";
            }

            if(hospitalRequest.BedCount !=null)
            {
                sqlQuery += "and h.BedCount in @Bedcount";
            }

            if (hospitalRequest.CountryCode != null)
            {
                sqlQuery += " and C.code = @CountryCode";

            }

            {
                sqlQuery += $@" ORDER BY Id DESC
                 OFFSET(@PageSize * (@PageIndex - 1)) ROWS FETCH NEXT @PageSize ROWS ONLY; ";
            }


            return Query<Hospital>(sqlQuery, new
            {
                hospitalRequest.CountryCode,
                hospitalRequest.SearchText,
                hospitalRequest.CityList,
                hospitalRequest.HospitalList,
                hospitalRequest.LanguageId,
                hospitalRequest.EstablishedYear,
                hospitalRequest.PageIndex,
                hospitalRequest.PageSize,
                hospitalRequest.BedCount,
                hospitalRequest.SpecialityId,
                hospitalRequest.TreatmentIds











            }) ; ;
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
        public bool InsertUser(RequestHospital requestHospital) {
            var sql = @"IF NOT EXISTS(SELECT 1 from Hospital where Title = @Title And CountryId = @CountryId And CityId = @CityId)
BEGIN
INSERT INTO Hospital	 
		   (CountryId,
			CityId,
			Title,
			Details,
			AdditionalDetails,
			Infrastructure,
			Address,
			BedCount,
			LanguageId,
			BrandId,
			Rank)
     VALUES          
          (@CountryId
           ,@CityId
           ,@Title
           ,@Details
           ,@AdditionalDetails
           ,@Infrastructure
           ,@Address
           ,@BedCount
           ,@LanguageId
           ,@BrandId
		   ,@Rank)
       
           
END
ELSE
BEGIN
UPDATE Hospital SET Title = @Title, Details = @Details, AdditionalDetails = @AdditionalDetails, Infrastructure = @Infrastructure, Address = @Address, BedCount= @BedCount, LanguageId = @LanguageId,BrandId = @BrandId, Rank = @Rank
Where Title = @Title and CountryId = @CountryId and CityId = @CityId;
END";
            return Execute(sql, new {
                CountryId = requestHospital.CountryId,
                CityId = requestHospital.CityId,
                Title = requestHospital.Title,
                Details = requestHospital.Details,
                AdditionalDetails = requestHospital.AdditionalDetails,
                Infrastructure = requestHospital.Infrastructure,
                Address = requestHospital.Address,
                BedCount = requestHospital.BedCount,
                LanguageId = requestHospital.LanguageId,
                BrandId = requestHospital.BrandId,
                Rank = requestHospital.Rank
                     }) > 0;
        }

         // public IEnumerable<Hospital> GetHospitals() {
         //   var sql = $@"SELECT * FROM Hospital ";
         //  return Query<Hospital>(sql);
    }
}


