using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Mail { get; set; }
        public DateTime? Doj { get; set; }
    }
}