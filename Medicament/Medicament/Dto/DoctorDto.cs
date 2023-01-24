using Medicament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medicament.Dto
{
    public class DoctorDto
    {
        public int idDoctor { get; set; }

        public String FirstName { get; set; }
       
        public String LastName { get; set; }
     
        public String Email { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
