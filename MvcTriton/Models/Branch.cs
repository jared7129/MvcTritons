using System;
using System.ComponentModel.DataAnnotations;

namespace MvcTriton.Models
{
    public class Branch
    {
        private const string V = "Please enter a valid Email";

        public int Id { get; set; }
        public string BranchName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]

        [RegularExpression(@"^([A-Za-z0-9][^'!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ][a-zA-z0- 
            9-._][^!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ]*\@[a-zA-Z0-9][^!&@\\#*$%^?<> 
                ()+=':;~`.\[\]{}|/,₹€ ]*\.[a-zA-Z]{2,6})$", ErrorMessage = V)]
        public string BranchEmail { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string Manager { get; set; }
    }
}