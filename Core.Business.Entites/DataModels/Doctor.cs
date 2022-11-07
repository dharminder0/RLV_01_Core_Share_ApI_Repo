using Core.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.DataModels
{
    public class Doctor
    {
        public Doctor() { }
        [Key(AutoNumber = true)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string DisplayName { get; set; }
        public string Designation { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public string Details { get; set; }
        public string AdditionalDetails { get; set; }
        public int? LanguageId { get; set; }
        public int? Rank { get; set; }
    }
}
