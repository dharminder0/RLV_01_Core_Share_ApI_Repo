using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Services.Abstract {
    public interface ISpecialityService {
        object SpecialityList(string countryCode);
    }
}
