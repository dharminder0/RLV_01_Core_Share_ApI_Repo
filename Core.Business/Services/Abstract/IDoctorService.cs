using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Services.Abstract
{
    public  interface IDoctorService
    {
        List<Doctor> GetDoctors();
        object GetDoctor(DoctorRequest doctorRequest);
        DoctorDetails DoctorDetails(int id);


    }
}
