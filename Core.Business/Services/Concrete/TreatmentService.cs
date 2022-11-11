using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;

namespace Core.Business.Services.Concrete {
    public class TreatmentService : ITreatmentService {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentService(ITreatmentRepository treatmentRepository) {
            _treatmentRepository = treatmentRepository;
        }


        public object TreatmentInfoById(string countryCode) {
            try {
                if (!string.IsNullOrWhiteSpace(countryCode)) {
                    var dbUser = _treatmentRepository.GetTreatmentInfoById(countryCode).ToList();
                    if (dbUser != null) {
                        return dbUser;
                    }
                }
                return null;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

    }
}
