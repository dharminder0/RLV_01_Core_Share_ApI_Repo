using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Common.Extensions;
using Core.Data.Repositories.Abstract;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace Core.Business.Services.Concrete {
    public class TreatmentService : ITreatmentService {
        private readonly ITreatmentRepository _treatmentRepository;
        public TreatmentService(ITreatmentRepository treatmentRepository) {
            _treatmentRepository = treatmentRepository;
        }


        public object TreatmentInfoById(string countryCode) {
            try {
                if (!string.IsNullOrWhiteSpace(countryCode)) {
                    if (countryCode.ContainsCI("IN")) {
                        countryCode = "1";

                        var dbUser = _treatmentRepository.GetTreatmentInfoById(countryCode).ToList();
                        if (dbUser != null) {
                            return dbUser;
                        }
                    }
                }
                return null;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


        public List<Treatment> TreatmentInfoBySpecialityId(TreatmentRequest treatmentRequest) {
            List<Treatment> treatmentObj = new List<Treatment>();
            try {
                if (treatmentRequest.SpecialityId.Contains(0)) {
                    var response = _treatmentRepository.TreatmentInfo();

                    if (response != null && response.Any()) {
                        treatmentObj.AddRange(response);
                    }
                    return treatmentObj;
                }

                if (treatmentRequest != null && treatmentRequest.SpecialityId.Any()) {
                    foreach (var item in treatmentRequest.SpecialityId) {
                        var res = _treatmentRepository.TreatmentInfoBySpecialityId(item).ToList();
                        if (res != null && res.Any()) {
                            treatmentObj.AddRange(res);
                        }
                    }
                    return treatmentObj;
                }


                var result = _treatmentRepository.TreatmentInfo();

                if (result != null && result.Any()) {
                    treatmentObj.AddRange(result);
                }
                return treatmentObj;

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}


