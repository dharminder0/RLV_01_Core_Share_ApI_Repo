using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.DataModels {
    public class Country {
        public Country () { }
        public int Id { get; set; }
        public string Code { get; set; }
        public int Title { get; set; }
    }
}
