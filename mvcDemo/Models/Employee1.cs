using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcDemo.Models
{
    public interface  IEmployee
    {

         int Id { get; set; }

         string Name { get; set; }
         string Gender { get; set; }
         string City { get; set; }
         DateTime? DateOfBirth { get; set; }
    }
    public class Employee1 : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}