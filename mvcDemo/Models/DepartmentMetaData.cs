using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcDemo.Models
{
    [MetadataType(typeof(DepartmentMetaData))]

    public partial class Departament
    {

    }
    public class DepartmentMetaData
    {
        public string Name { get; set; }
        public int DepartamentId { get; set; }
    }
}