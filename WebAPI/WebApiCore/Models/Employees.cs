using System;
using System.Collections.Generic;

namespace WebApiCore.Models
{
    public partial class Employees
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Mail { get; set; }
        public DateTime? Doj { get; set; }
    }
}
