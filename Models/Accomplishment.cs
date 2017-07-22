using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewballResume.Models
{
    [Authorize]
    public class Accomplishment
    {

        public int AccomplishmentID { get; set; }
        public int JobID { get; set; }

        [Required]
        [Display(Name = "Accomplishment")]
        [RegularExpression(@"^[A-Z\d].*$",
           ErrorMessage = "Please enter an Accomplishment starting with an uppercase letter or a number."
            )]
        public string Accomp { get; set; }

        //navigation
        // Accomplishments get one Job
        public Job Job { get; set; }
    }
}
