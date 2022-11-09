﻿using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Slapper.AutoMapper;

namespace Core.Business.Services.Abstract {
    public interface IHospitalsService {
        List<Hospital> GetHospitals();
        object GetHospitals(HospitalRequest hospitalRequest);
        object GetHospitalsById(int id);
        //HospitalDetails HospitalDetails(int id);
    }
}
