using Core.Business.Entites.DataModels;

namespace Core.Data.Repositories.Abstract {
    public interface ITreatmentRepository {
        IEnumerable<Treatment> GetTreatmentInfoById(string countryCode);
    }
}
