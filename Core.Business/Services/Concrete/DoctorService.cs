﻿using Core.Business.Entites.DataModels;
using Core.Business.Entites.RequestModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;
using Core.Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Services.Concrete
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;

        }
       
        public List<Doctor> GetDoctors()
        {
            return _doctorRepository.GetDoctors().ToList();

        }
        public List<Doctor> GetDoctorDetailsById(int id)
        {
            return _doctorRepository.GetDoctorById(id).ToList();
        }
        public object GetDoctor(DoctorRequest doctorRequest)
        {

            return _doctorRepository.GetDoctor(doctorRequest).ToList();

        }
    }
}
