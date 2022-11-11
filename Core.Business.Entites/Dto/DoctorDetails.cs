using Core.Business.Entites.DataModels;

namespace Core.Business.Entites.Dto {
    public class DoctorDetails {
        public Doctor Doctor { get; set; }
        public List<MediaFileDto> Images { get; set; }
        //public string Displayname { get; set; }
        //public string Designation { get; set; }
        //public string Qualification { get; set; }
        //public string Experience { get; set; }
        //public string Details { get; set; }
        //public int LanguageId { get; set; }
        //public string Filename { get; set; }
        //public string MediaDetails { get; set; }
        //public object UpdatedBy { get; set; }
        //public DateTime UpdatedOn { get; set; }
    }
    //public class Root
    //{
    //    public List<DoctorDetails> doctorDetails { get; set; }
    //}

}