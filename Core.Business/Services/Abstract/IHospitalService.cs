using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Business.Entites.ResponseModels;

namespace Core.Business.Services.Abstract {
    public interface IHospitalService {
        
        object GetHospital(HospitalRequest hospitalRequest);
        HospitalDetails HospitalDetails(int id);
        bool CreateHospital(RequestHospital requestHospital);
        
        //List<Hospital> GetHospital();

    }
}
