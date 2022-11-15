using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Entites.ResponseModels;

namespace Core.Business.Services.Abstract {
    public  interface IDoctorService
    {
        List<Doctor> GetDoctors();
        object GetDoctor(DoctorRequest doctorRequest);
        DoctorDetails DoctorDetails(int id);
        bool CreateDoctor(RequestDoctor requestDoctor);
        bool AddDoctorSpeciality(RequestDoctorSpeciality requestDoctorSpeciality);


    }
}
