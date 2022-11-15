using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;

namespace Core.Business.Services.Abstract {
    public interface ITreatmentService {
        object TreatmentInfoById(string countryCode);
        List<Treatment> TreatmentInfoBySpecialityId(TreatmentRequest treatmentRequest);
    }
}
