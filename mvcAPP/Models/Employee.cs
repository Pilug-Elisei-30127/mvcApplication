using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace mvcAPP.Models
{
    public class Employee
    {

        [Key]
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Full Name ")]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        [DisplayName("Hire Date")]
       // [DataType(DataType.Date)]
        [ReadOnly(true)]

        //  [DisplayFormat(DataFormatString = "yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } 
        public string ConfirmEmailAdress { get; set; }
        [Required]
        [ScaffoldColumn(true)]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [DisplayFormat(NullDisplayText = "No personal web site")]
        [DataType(DataType.Url)]
        [UIHint("EmployeePersonalWebSite")]
        public string PersonalWebSite { get; set; }
        public string Photo { get; set; }
        public string AlternateText { get; set; }
    }
}