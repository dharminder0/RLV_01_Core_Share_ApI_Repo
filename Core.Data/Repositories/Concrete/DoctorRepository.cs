using Core.Business.Entites.DataModels;
using Core.Common.Contracts;
using Core.Common.Data;
using Core.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Slapper.AutoMapper;

namespace Core.Data.Repositories.Concrete
{
    public class DoctorRepository: DataRepository<Doctor>,IDoctorRepository
    {
        public IEnumerable<Doctor> GetDoctors()
        {
            var sql = $@"SELECT * FROM Doctor ";
            return Query<Doctor>(sql);
        }
        public IEnumerable<Doctor> GetDoctorById( int id)
        {
            var sql = $@"SELECT * FROM Doctor WHERE Id=@id";
            return Query<Doctor>(sql, new { id });
        }
    }
}
