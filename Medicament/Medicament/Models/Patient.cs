using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medicament.Models
{
    public class Patient
    {
        [Key]
        public int idPatient { get; set; }
        [Required]
        [MaxLength(100)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public String LastName { get; set; }
        [Required]
        public DateTime Birhtdate { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }

    }
}
