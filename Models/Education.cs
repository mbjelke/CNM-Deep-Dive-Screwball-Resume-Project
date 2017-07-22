using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewballResume.Models
{
    [Authorize]
    public class Education
    {

        public int EducationID { get; set; }
        public int ApplicantID { get; set; }

        [Required]
        [Display(Name = "Organization Name")]
        public string OrgName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [StringLength(4)]
        [RegularExpression(@"^[0-9]*$")]
        [Display(Name = "From Year")]
        public string From { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "To Year (if applicable)")]
        public string To { get; set; }

        [Required]
        public bool isCurrent { get; set; }

        [Display(Name = "Degree Attained (if applicable)")]
        public string DegreeAttained { get; set; }

        [Required]
        [Display(Name = "Fields(s) of Concentration")]
        public string ConcentrationIn { get; set; }

        //navigation
        // Educations get one Applicant.  Yes, Educations.  Just like we discussed in the Person Model.  Geesh.
        public virtual Applicant Applicant { get; set; }
    
    }
}
