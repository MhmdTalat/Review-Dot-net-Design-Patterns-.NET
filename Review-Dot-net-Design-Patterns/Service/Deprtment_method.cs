using Review_Dot_net_Design_Patterns.model;

public class Deprtment_method
{
    private Department department;
    public Deprtment_method(int id, string name, int emp_id, string emp_address = "", string emp_email = "", string emp_phone = "") => department = new Department
    {
        Id = id,
        Name = name,
        Employees = new List<Emp_data>
            {
                new Emp_data
                {
                    Emp_id = emp_id,
                    Emp_name = name,
                    Emp_address = emp_address,
                    Emp_email = emp_email,
                    Emp_phone = emp_phone,
                    DepartmentId = id
                }
            }
    };
}