using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewballResume.Models
{
    [Authorize]
    public class Reference
    {
        public int ReferenceID { get; set; }
        public int ApplicantID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9''-''/'\s]*$",
           ErrorMessage = "Please, enter your first name starting with an uppercase letter."
            )]
        public string FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        [StringLength(1)]
        [RegularExpression(@"^[A-Z]$",
           ErrorMessage = "Please, enter your middle initial as an uppercase letter."
            )]
        public string MiddleInit { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9''-''/'\s]*$",
           ErrorMessage = "Please, enter your last name starting with an uppercase letter."
            )]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        // because there is no 'set' it's just Full Name
        [NotMapped]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9''-''/'\s]*$",
        //    ErrorMessage = "Please, enter your reference's title starting with an uppercase letter."
        //    )]
        public string ReferenceDesc { get; set; }


        //navigation
        // References get one Applicant
        public  Applicant Applicant { get; set; }
    }
}
