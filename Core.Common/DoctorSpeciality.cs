using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.DataModels {
    public class DoctorSpeciality {
        public DoctorSpeciality() { }
        public int Id { get; set; }
        public string Details { get; set; }
        public string Symbol { get; set; }
        public int LanguageId { get; set; }


    }
}
