using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Business.Entites.ResponseModels;
using Core.Common.Data;

namespace Core.Data.Repositories.Abstract {
    public interface IDoctorRepository : IDataRepository<Doctor> {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctorById(int id);
        IEnumerable<Doctor> GetDoctor(DoctorRequest doctorRequest);
        DoctorDetails GetAllDoctorsMediaDetails( int id);
        bool InsertDoctor(RequestDoctor requestDoctor);

    }
}
