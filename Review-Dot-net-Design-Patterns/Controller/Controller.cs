public class controller
{
    private Emp_method empMethod;
    private Deprtment_method departmentMethod;

    public controller()
    {
        empMethod = new Emp_method(0, "", "", "", "");
        departmentMethod = new Deprtment_method(0, "", 0);
    }


    // PUT - update an existing employee's details via console screen
    public void UpdateEmpDetails()
    {
        var current = empMethod.GetEmpData();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("=== Update Employee Details ===");
        Console.WriteLine("(Press Enter to keep the current value)");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"Employee Name [{current.Emp_name}]: ");
        Console.ForegroundColor = ConsoleColor.White;
        string? name = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"Employee Address [{current.Emp_address}]: ");
        Console.ForegroundColor = ConsoleColor.White;
        string? address = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"Employee Email [{current.Emp_email}]: ");
        Console.ForegroundColor = ConsoleColor.White;
        string? email = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"Employee Phone [{current.Emp_phone}]: ");
        Console.ForegroundColor = ConsoleColor.White;
        string? phone = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"Department ID [{current.DepartmentId}]: ");
        Console.ForegroundColor = ConsoleColor.White;
        string? deptIdInput = Console.ReadLine();
        int? deptId = int.TryParse(deptIdInput, out int parsed) ? parsed : null;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"Department Name [{current.Department?.Name ?? "N/A"}]: ");
        Console.ForegroundColor = ConsoleColor.White;
        string? deptName = Console.ReadLine();

        // delegate update to service layer
        empMethod.UpdateEmpData(name, address, email, phone, deptId, deptName);

        bool isValid = empMethod.ValidateEmpData();
        if (isValid)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nEmployee ID {current.Emp_id} updated successfully.");
            Console.ResetColor();
            empMethod.GetEmpDetails(empMethod.GetEmpData());
        }
    }

    public void Run()
    {
        empMethod.readEmpDetails();
        var empData = empMethod.GetEmpData();

        Console.WriteLine();
        Console.WriteLine("Employee Details:");
        Console.WriteLine($"ID: {empData.Emp_id}");
        Console.WriteLine($"Name: {empData.Emp_name}");
        Console.WriteLine($"Address: {empData.Emp_address}");
        Console.WriteLine($"Email: {empData.Emp_email}");
        Console.WriteLine($"Phone: {empData.Emp_phone}");

        // You can add more logic here to handle department details if needed
    }
}