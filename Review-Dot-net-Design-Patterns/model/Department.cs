using System.Collections.Generic;

namespace Review_Dot_net_Design_Patterns.model
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Emp_data> Employees { get; set; } = new();
    }
}