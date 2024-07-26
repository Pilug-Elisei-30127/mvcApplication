using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvcDemo.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }
    public class EmployeeMetaData
    {
        //[Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [Display(Name="Departmentr")]
        public int DepartamentId { get; set; }
    }
}