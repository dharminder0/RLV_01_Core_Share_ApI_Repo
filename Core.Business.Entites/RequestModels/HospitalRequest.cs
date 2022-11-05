using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.RequestModels {
    public class HospitalRequest {
        public int CountryId { get; set; }
        public List<int> CityList { get; set; }
        public List<int> HospitalList { get; set; }
        public int LanguageId { get; set; }
    }
}
