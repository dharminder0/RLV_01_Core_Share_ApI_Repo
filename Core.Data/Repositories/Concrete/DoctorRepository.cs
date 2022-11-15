using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Entites.ResponseModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;

namespace Core.Data.Repositories.Concrete
{
    public class DoctorRepository: DataRepository<Doctor>,IDoctorRepository
    {
        public IEnumerable<Doctor> GetDoctors()
        {
            var sql = $@"SELECT * FROM Doctor ";
            return Query<Doctor>(sql);
        }
        public Doctor GetDoctorById( int id)
        {
            var sql = $@"SELECT * FROM Doctor WHERE Id = @id";
            return QueryFirst<Doctor>(sql, new { id });
        }
        public IEnumerable<Doctor> GetDoctor(DoctorRequest doctorRequest)
        {
            var sqlQuery = $@"select d.* from doctor d join users U on 
                d.userid = U.id ";

            if (doctorRequest.HospitalList != null && doctorRequest.HospitalList.Any())
            {
                
                sqlQuery += " JOin [DoctorHospitalRef] DHF on DHF.DoctorUserid = d.userId ";
            }
            if (doctorRequest.CountryCode != null && doctorRequest.CountryCode.Any())
            {
                sqlQuery += " JOin [Country] C on C.Id = U.CountryId ";

            }
            if(doctorRequest.specialityId !=null )
            {
                sqlQuery += " join [DoctorSpecialityRef] DS  on DS.DoctorUserId=d.Userid";

            }
          

            sqlQuery += " where usertype =3  and  languageid = @LanguageId  ";
         

            if (!string.IsNullOrWhiteSpace(doctorRequest.SearchText))
            {
                sqlQuery += $@"and DisplayName like '%{doctorRequest.SearchText}%'  ";
            }



            if (doctorRequest.HospitalList != null && doctorRequest.HospitalList.Any())
            {
                sqlQuery += " and DHF.HospitalId in @HospitalList ";
            }

            if (doctorRequest.specialityId != null && doctorRequest.specialityId.Any())
            {
                sqlQuery += " and Ds.SpecialityId in @SpecialityId ";
            }

            if (doctorRequest.YearExperience != null && doctorRequest.YearExperience.Any())
            {
                int minRange = 0; int maxRange = 0;
                if (doctorRequest.YearExperience.Count > 1)
                {
                    minRange = doctorRequest.YearExperience[0];
                    maxRange = doctorRequest.YearExperience[1];
                }
                if (minRange > 0 && maxRange > 0)
                {
                    sqlQuery += $@" and  d.YearExperience between {minRange} and {maxRange} ";
                }
            }

            if (doctorRequest.TreatmentIds != null && doctorRequest.TreatmentIds.Any())
            {
                sqlQuery += " and Ds.TreatmentId in @TreatmentIds ";
            }



            if (doctorRequest.CountryCode != null)
            {
                sqlQuery += " and C.code = @CountryCode";

            }
            {
                sqlQuery += $@" ORDER BY Userid DESC
                 OFFSET(@PageSize * (@PageIndex - 1)) ROWS FETCH NEXT @PageSize ROWS ONLY; ";
            }
        



            return Query<Doctor>(sqlQuery, doctorRequest);
        }
        public DoctorDetails GetAllDoctorsMediaDetails(int id)
        {
            var sqlQuery = $@"select dc.displayname,dc.designation,dc.id,dc.qualification,dc.experience,dc.details,dc.languageid,mm.Filename ,mm.mediadetails ,mm.updatedby,mm.updatedon  from doctor dc  join MediaFile mm   on
                dc.userid = mm.EntityId  where dc.id = @id";
            return QueryFirst<DoctorDetails>(sqlQuery,new { id });
        }
        public bool InsertDoctor(RequestDoctor requestDoctor) {
            var sql = @"IF NOT EXISTS(SELECT 1 from Doctor where UserId = @UserId )
BEGIN
INSERT INTO Doctor	 
		   (
            UserId
           ,DisplayName
           ,Designation
           ,Qualification
           ,Experience
           ,Details
           ,AdditionalDetails
           ,LanguageId
           ,Rank
           ,YearExperience
           ,Range)
     VALUES          
          (
            @UserId
           ,@DisplayName
           ,@Designation
           ,@Qualification
           ,@Experience
           ,@Details
           ,@AdditionalDetails
           ,@LanguageId
           ,@Rank
           ,@YearExperience
           ,@Range)
       
           
END
ELSE
BEGIN
UPDATE Doctor SET DisplayName = @DisplayName, Designation = @Designation, Qualification = @Qualification, Experience = @Experience, Details = @Details, AdditionalDetails= @AdditionalDetails, LanguageId = @LanguageId, Rank = @Rank, YearExperience = @YearExperience ,Range =@Range
Where UserId = @UserId;
END";
            return Execute(sql, new {
                UserId = requestDoctor.UserId
           , DisplayName = requestDoctor.DisplayName
           , Designation = requestDoctor.Designation
           , Qualification = requestDoctor.Qualification
           , Experience = requestDoctor.Experience
           , Details = requestDoctor.Details
           , AdditionalDetails = requestDoctor.AdditionalDetails
           , LanguageId = requestDoctor.LanguageId
           , Rank = requestDoctor.Rank
           ,YearExperience = requestDoctor.YearExperience
           ,Range = requestDoctor.Range
            }) > 0;
        }
        public bool InsertDoctorSpecialityRef(RequestDoctorSpeciality requestDoctorSpeciality) {
            var sql = @"IF NOT EXISTS (SELECT * from DoctorSpecialityRef where DoctorUserId = @DoctorUserId)
BEGIN
INSERT INTO DoctorSpecialityRef	 
		   (SpecialityId,
			DoctorUserId,
			Details,
			Symbol,
			TreatmentAmount,
			TreatmentId)
     VALUES          
          (@SpecialityId
           ,@DoctorUserId
           ,@Details
           ,@Symbol
           ,@TreatmentAmount
           ,@TreatmentId)
       
           
END
ELSE
BEGIN
UPDATE DoctorSpecialityRef SET SpecialityId = @SpecialityId,Details = @Details,symbol = @Symbol,TreatmentAmount = @TreatmentAmount,TreatmentId= @TreatmentId
Where DoctorUserId = @DoctorUserId
END"; 
            return Execute(sql, new {
                SpecialityId = requestDoctorSpeciality.SpecialityId,
                DoctorUserId = requestDoctorSpeciality.DoctorUserId,
                Details = requestDoctorSpeciality.Details,
                Symbol = requestDoctorSpeciality.Symbol,
                TreatmentAmount = requestDoctorSpeciality.TreatmentAmount,
                TreatmentId = requestDoctorSpeciality.TreatmentId,
            }) > 0;

        }
    }
}
