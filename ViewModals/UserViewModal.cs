using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication8.ViewModals
{
    public class UserViewModal
    {
        public int id { set; get; }
        [Display(Name = "Name"), Required]
        public string FirstName { set; get; }
        [Display(Name = "LastName"), Required]
        public string LastName { set; get; }
        [Display(Name = "Email"), Required,EmailAddress]
        public string Email { set; get; }

        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [Display(Name = "Password"), Required]
        public string Password { set; get; }
        [Display(Name = "Data Of Birth"), Required]
        public System.DateTime DateOfBirth { set; get; }

    }
}