using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace mvcAPP.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public string Country { get; set; }
    }
}   