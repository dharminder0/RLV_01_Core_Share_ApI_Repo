using Core.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.DataModels
{
    public class City
    {
        public City() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public string CityName { get; set; }
        public int? CountryId { get; set; }

    }
}
