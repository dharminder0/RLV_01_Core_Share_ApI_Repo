using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Common.Data;

namespace Core.Data.Repositories.Abstract {
    public interface IDoctorRepository:IDataRepository<Doctor>
    {
        IEnumerable<Doctor> GetDoctors();
        IEnumerable<Doctor> GetDoctorById(int Userid);
        IEnumerable<Doctor> GetDoctor(DoctorRequest doctorRequest);


    }
}
