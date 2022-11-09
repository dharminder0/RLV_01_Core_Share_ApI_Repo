using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites
{

    public enum MediaType
    {
        Logo = 1,
        Image = 2,
        Video = 3,
        Pdf = 4,
    }

    public enum EntityType
    {
        User = 1,
        Brand = 2,
        Doctor = 3,
        Hospital = 4,
        Speciality = 5,
        Treatment = 6,
    }

    public enum UserType
    {
        Superadmin = 1,
        Admin = 2,
        Doctor = 3,
        Patient = 4,
    }
}
