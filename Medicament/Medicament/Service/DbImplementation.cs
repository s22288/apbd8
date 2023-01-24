using Medicament.Dto;
using Medicament.Migrations;
using Medicament.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicament.Service
{
    public class DbImplementation : ConnectToDb

    {
        private readonly MainDbContext _dbContext;
      public DbImplementation(MainDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<IEnumerable<DoctorDto>> GetDoctors(int id)
        {
            return (IEnumerable<DoctorDto>)await _dbContext.Doctors.Where(e => e.idDoctor == id ).ToListAsync();
        }

        public async Task<Boolean> insertDoctor(DoctorDto doctor)
        {
            Doctor doctor1 = new Doctor();
            doctor1.idDoctor = doctor.idDoctor;
            doctor1.FirstName = doctor.FirstName;
            doctor1.LastName = doctor.LastName;
            doctor1.Email = doctor.Email;
            _dbContext.Doctors.Add(doctor1);
            _dbContext.SaveChanges();

            return true;
        }

        public async Task remove(int id)
        {
            var doc = await _dbContext.Doctors.Where(e => e.idDoctor == id).FirstOrDefaultAsync();
            _dbContext.Remove(doc);
            await _dbContext.SaveChangesAsync();
           
        }

        public async Task<Boolean> updateDoctor(DoctorDto doctor)
        {
            Doctor doc = new Doctor();
            doc.idDoctor = doctor.idDoctor;
            doc.FirstName = doctor.FirstName;
            doc.LastName = doctor.LastName;
            doc.Email = doctor.Email;
            var entity = _dbContext.Find(idDoctor: doctor.idDoctor);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(doc);
            return  true;
        }
    }
}
