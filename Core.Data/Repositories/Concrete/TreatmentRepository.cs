﻿using Core.Business.Entites.DataModels;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Concrete {
    public class TreatmentRepository : DataRepository<Treatment>, ITreatmentRepository {
        public IEnumerable<Treatment> GetTreatmentInfoById(string countryCode) {
            var sql = $@"select * from Treatment where LanguageId = @countryCode";
            return Query<Treatment>(sql, new { countryCode });
        }
    }
}