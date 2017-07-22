using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewballResume.Models
{
    [Authorize]
    public class Certification
    {
        public int CertificationID { get; set; }
        public int ApplicantID { get; set; }

        [Required]
        [Display(Name = "Certification or License Name")]
        [RegularExpression(@"^([A-Z\d]).*$",
               ErrorMessage = "Please, enter a Certification Name starting with an uppercase letter or number."
                )]
        public string CertName { get; set; }

        [Display(Name = "Issuing Authority")]
        public string CertAuthority { get; set; }

        [Display(Name = "License Number")]
        public string LicenseNum { get; set; }

        [Required]
        [Display(Name = "Issue Date")]
        public DateTime From { get; set; }

        [Display(Name = "Expiry Date")]
        public DateTime To { get; set; }

        [Display(Name = "License Does Not Expire?")]
        public bool IsEternal { get; set; }

        [Display(Name = "Enter Certification URL (if applicable)")]
        [DataType(DataType.Url)]
        public string CertURL { get; set; }

        //navigation
        // Certifications get one Applicant
        public virtual Applicant Applicant { get; set; }

    }
}
