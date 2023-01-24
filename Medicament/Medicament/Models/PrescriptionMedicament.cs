using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Medicament.Models
{
    public class PrescriptionMedicament
    {
       
        [ForeignKey("IdPrescription")]
        public virtual Prescription Prescription { get; set; }
        
        [ForeignKey("idMedicament")]
        public virtual Medicament Medicament { get; set; }
        public int idMedicament { get; set; }
      
        public int IdPrescription { get; set; }
        [Required]
        [MaxLength(100)]
        public int Dose { get; set; }
        [Required]
        [MaxLength(100)]
        public String Details { get; set; }

       
    }
}
