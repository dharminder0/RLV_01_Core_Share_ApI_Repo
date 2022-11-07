﻿using Core.Business.Entites.DataModels;
using Core.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Abstract
{
    public interface ICountryRepository : IDataRepository<Country>
    {
        public IEnumerable<Country> GetAllCountry();
        
    }
}