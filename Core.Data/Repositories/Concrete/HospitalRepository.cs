using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Entites.ResponseModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete {

    public class HospitalRepository : DataRepository<Hospital>, IHospitalRepository {
        
        public IEnumerable<Hospital> GetHospitals(HospitalRequest hospitalRequest) {
            var sqlQuery = $@"SELECT TOP 10 * FROM Hospital ";

            if (hospitalRequest.CountryCode != null && hospitalRequest.CountryCode.Any()) {
                sqlQuery += " JOin [Country] C on C.Id = Hospital.CountryId ";

            }
            if (hospitalRequest.CityList != null && hospitalRequest.CityList.Any()) {
                sqlQuery += " JOin [City] Ct on Ct.CountryId = C.id ";

            }
            sqlQuery += " where  languageid = @LanguageId ";



            if (!string.IsNullOrWhiteSpace(hospitalRequest.SearchText)) {

                sqlQuery += $@"and Title like '%{hospitalRequest.SearchText}%'  ";
            }



            if (hospitalRequest.CityList != null && hospitalRequest.CityList.Any())
            {
                sqlQuery += "and cityid in @CityList ";
            }


            if (hospitalRequest.HospitalList != null && hospitalRequest.HospitalList.Any()) {
                sqlQuery += " and hospital.id in @HospitalList ";
            }
            if (hospitalRequest.CountryCode != null) {
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


