using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewballResume.Models
{
    [Authorize]
    public class Affiliation
    {
        public int AffiliationID { get; set; }
        public int ApplicantID { get; set; }

        [Required]
        [Display(Name = "Organization")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9''-''/'\s]*$",
           ErrorMessage = "Please, enter an Organization starting with an uppercase letter."
            )]
        public string AffilOrg { get; set; }

        [Display(Name = "Role or Title")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9''-'\s]*$",
           ErrorMessage = "Please, enter a Role or Title starting with an uppercase letter."
            )]
        public string Role { get; set; }

        [Required]
        [Display(Name = "Role Type")]
        [RegularExpression(@"((?:[Mm](ember))?)((?:[Oo](fficer))?)((?:[Vv](olunteer))?)((?:[Oo](ther))?)", ErrorMessage = "Please enter Role Type: Member, Officer, Volunteer, or Other.")]
        public string Type { get; set; }

        [Required]
        [StringLength(4)]
        [RegularExpression(@"^[0-9]*$")]
        [Display(Name = "From Year")]
        public string From { get; set; }

        [StringLength(4)]
        [RegularExpression(@"^[0-9]*$")]
        [Display(Name = "To Year")]
        public string To { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "URL")]
        public string AffilURL { get; set; }

        [Display(Name = "Current?")]
        public bool IsCurrent { get; set; }

        //navigation
        // Affiliations get one Applicant
        public virtual Applicant Applicant { get; set; }
     
    }
}
