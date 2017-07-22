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
    public class Applicant
    {

        public int ID { get; set; }

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



        [Required]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9''-'\s]*$",
           ErrorMessage = "Please, enter your city starting with an uppercase letter."
            )]
        [StringLength(25)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [DataType(DataType.PostalCode, ErrorMessage = "Please, enter your zip code is the proper format.")]
        public string Zip { get; set; }

        [DataType(DataType.Url)]
        public string Website { get; set; }

        [DataType(DataType.Url)]
        public string LinkedIn { get; set; }

        [DataType(DataType.Url)]
        public string Facebook { get; set; }

        [DataType(DataType.Url)]
        public string Twitter { get; set; }

        [Display(Name = "Enter your Professional Statement. This may be as long or short as you wish.")]
        public string ProfessionalStatement { get; set; }

        // because there is no 'set' it's just City, State Zip
        [NotMapped]
        public string CityStateZip
        {
            get
            {
                return String.Format("{0}, {1} {2}", City, State, Zip);
            }
        }



        // because there is no 'set' it's just Full Name
        [NotMapped]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        // An applicant gets many Qualifications
        public ICollection<Qualification> Qualifications { get; set; }

        // An applicant gets many Jobs
        public ICollection<Job> Jobs { get; set; }
        
        // An applicant gets many Affiliations
        public ICollection<Affiliation> Affiliations { get; set; }

        // An applicant can have many Certifications
        public ICollection<Certification> Certifications { get; set; }

        // An applicant can have many Educations
        public ICollection<Education> Educations { get; set; }

        // An applicant can have many References
        public ICollection<Reference> References { get; set; }
    }
}
