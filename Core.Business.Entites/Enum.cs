namespace Core.Business.Entites {

    public enum MediaType {
        Logo = 1,
        Image = 2,
        Video = 3,
        Pdf = 4,
    }

    public enum EntityType {
        User = 1,
        Brand = 2,
        Doctor = 3,
        Hospital = 4,
        Speciality = 5,
        Treatment = 6,
    }

    public enum UserType {
        Superadmin = 1,
        Admin = 2,
        Doctor = 3,
        Patient = 4,
    }
    
    public enum BolbType {
        Doctor = 1,
        Hospital = 2,
        Image= 3,
        Logo = 4,
        Prescription = 5,
        User = 6,
    }
}
