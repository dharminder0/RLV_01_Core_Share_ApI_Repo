using Core.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.DataModels {
    public class HospitalTreatmentRef
    {
        public HospitalTreatmentRef() { }
        [Key(AutoNumber = true)]
        public int? Id { get; set; }
        public int? HospitalId { get; set; }
        public int? TreatmentId { get; set; }
        public decimal TreatmentAmount { get; set; }

    }
}
