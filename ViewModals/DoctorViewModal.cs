using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication8.ViewModals
{
    public class DoctorViewModal
    {
        [Display(Name="Name"), Required]
        public string Name { get; set; }

        [Display(Name = "Age"), Required]
        public int Age { get; set; }
        [Display(Name = "Surname"),Required]
        public string Surname { get; set; }
    }
}