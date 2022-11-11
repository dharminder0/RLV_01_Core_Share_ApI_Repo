﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.RequestModels
{
    public class DoctorRequest
    {
        public string SearchText { get; set; } = "";
        public string CountryCode { get; set; }
        public List<int>? CityList { get; set; } 
        public List<int>? HospitalList { get; set; } 
        public int LanguageId { get; set; } = 1;
        public int YearExperience { get; set; }
        public int ? specialityId { get; set; }

    }
}
