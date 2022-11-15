using Core.Business.Services.Abstract;
using Core.Common.Extensions;
using Core.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Services.Concrete {
    public class SpecialityService : ISpecialityService {

        private readonly ISpecialityRepository _specialityRepository;
        public SpecialityService(ISpecialityRepository specialityRepository) {
            _specialityRepository = specialityRepository;
        }

        public object SpecialityList(string countryCode) {
            try {
                if (!string.IsNullOrWhiteSpace(countryCode)) {
                    if (countryCode.ContainsCI("IN")) {
                        countryCode = "1";

                        var dbUser = _specialityRepository.GetSpecialityInfo(countryCode).ToList();
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

    }
}
