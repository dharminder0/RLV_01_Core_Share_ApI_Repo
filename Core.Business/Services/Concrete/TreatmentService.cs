﻿using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;
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


        public List<Treatment> TreatmentInfoBySpecialityId(TreatmentRequest treatmentRequest) {
            List<Treatment> treatmentObj =  new List<Treatment>();
            try {
                if (treatmentRequest != null && treatmentRequest.SpecialityId.Any())   {
                    foreach(var item in treatmentRequest.SpecialityId) {
                        Treatment treatment = new Treatment();
                        var res  = _treatmentRepository.TreatmentInfoBySpecialityId(item).ToList();
                        if(res != null && res.Any()) {
                            treatmentObj.AddRange(res);
                        }
                    }
                        return treatmentObj;
                }
                return null;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


       
    }
}

    
