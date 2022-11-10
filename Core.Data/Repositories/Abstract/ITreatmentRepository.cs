﻿using Core.Business.Entites.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Abstract {
    public interface ITreatmentRepository {
        IEnumerable<Treatment> GetTreatmentInfoById(int id);
    }
}
