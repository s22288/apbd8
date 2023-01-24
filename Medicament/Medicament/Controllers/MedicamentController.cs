using Medicament.Dto;
using Medicament.Models;
using Medicament.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicament.Controllers
{
    [ApiController]
    [Route("medicament")]
    public class MedicamentController : Controller

    {
        private DbImplementation dbImplementation;
        public MedicamentController(DbImplementation dbImp)
        {
            dbImp = dbImplementation;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetMedicamentsAsync(int idDoctor)
        {
          var doctors = dbImplementation.GetDoctors(idDoctor);


            return Ok(doctors);
        }
          [HttpDelete]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            dbImplementation.remove(idDoctor);


            return Ok("remove doctor with id" + idDoctor); ;
        }
        [HttpPost]
        public async Task<IActionResult> InsertDoctor(DoctorDto idDoctor)
        {
            var doctors = dbImplementation.insertDoctor(idDoctor);


            return Ok(doctors);
        }

        [HttpPut]
        public async Task<IActionResult> updateDoctor(DoctorDto idDoctor)
        {
            dbImplementation.updateDoctor(idDoctor);
            

            return Ok("update doctor ");
        }

        [HttpGet]
        public async Task<IActionResult> GetPrescription(Patient p,Doctor d, List<Models.Medicament> medicaments)

        {



            return null;

        }
    }
}
