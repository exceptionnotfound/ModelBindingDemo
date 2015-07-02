using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelBindingSample.Models
{
    public class Employee
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public WorkLocation WorkLocation { get; set; }
    }
}