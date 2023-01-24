using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medicament.Models
{
    public class Doctor
    {
        [Key]
        public int idDoctor { get; set; }
        [Required]
        [MaxLength(100)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public String LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public String Email { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }


    }
}
