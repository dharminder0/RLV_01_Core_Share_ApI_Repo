using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.RequestModels;
using Core.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Repositories.Abstract
{
    public interface IDoctorRepository:IDataRepository<Doctor>
    {
       IEnumerable<Doctor> GetDoctors();
         Doctor GetDoctorById(int id);
        IEnumerable<Doctor> GetDoctor(DoctorRequest doctorRequest);
        DoctorDetails GetAllDoctorsMediaDetails( int id);
       


    }
}
