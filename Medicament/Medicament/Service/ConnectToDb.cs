using Medicament.Dto;
using Medicament.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicament.Service
{
    public interface ConnectToDb
    {
        Task<IEnumerable<DoctorDto>> GetDoctors(int id);
        Task<Boolean> insertDoctor(DoctorDto doctor);
        Task remove(int id);
        Task<Boolean> updateDoctor(DoctorDto doctor);
       

    }
}
