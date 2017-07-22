using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewballResume.Models
{
    [Authorize]
    public class Qualification
    {

        public int QualificationID { get; set; }
        public int ApplicantID { get; set; }

        [RegularExpression(@"^[A-Z\d].*$",
         ErrorMessage = "Please, enter a Skill or Qualification starting with an uppercase letter or digit."
          )]
        public string Skill { get; set; }

        //navigation
        // Qualifications get one Applicant
        public Applicant Applicant { get; set; }
    }
}
