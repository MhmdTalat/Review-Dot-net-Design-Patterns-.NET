using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Review_Dot_net_Design_Patterns.model
{
    public class Emp_data
    {
        public int Emp_id { get; set; }
        public string? Emp_name { get; set; }
        public string? Emp_address { get; set; }
        public string? Emp_email { get; set; }
        public string? Emp_phone { get; set; }
    }
}