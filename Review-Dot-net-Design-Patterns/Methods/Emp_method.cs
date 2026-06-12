using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Review_Dot_net_Design_Patterns.model;

public class Emp_method
{
    private Emp_data emp_data;

    // Default constructor
    public Emp_method(int emp_id, string emp_name, string emp_address, string emp_email, string emp_phone)
    {
        emp_data = new Emp_data();
        emp_data.Emp_id = emp_id;
        emp_data.Emp_name = emp_name;
        emp_data.Emp_address = emp_address;
        emp_data.Emp_email = emp_email;
        emp_data.Emp_phone = emp_phone;

    }

    public void readEmpDetails()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter Employee Details:");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Enter Employee ID: ");
        Console.ForegroundColor = ConsoleColor.White;
        emp_data.Emp_id = int.Parse(Console.ReadLine() ?? "0");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Enter Employee Name: ");
        Console.ForegroundColor = ConsoleColor.White;
        emp_data.Emp_name = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Enter Employee Address: ");
        Console.ForegroundColor = ConsoleColor.White;
        emp_data.Emp_address = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Enter Employee Email: ");
        Console.ForegroundColor = ConsoleColor.White;
        emp_data.Emp_email = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Enter Employee Phone: ");
        Console.ForegroundColor = ConsoleColor.White;
        emp_data.Emp_phone = Console.ReadLine();

        // Validate employee data
        ValidateEmpData();
    }

    // Method to validate employee data
    public bool ValidateEmpData()
    {
        var errors = EmpDataValidator.ValidateEmpData(emp_data);
        EmpDataValidator.DisplayValidationErrors(errors);
        return errors.Count == 0;
    }

    // Method to get the employee data
    public Emp_data GetEmpData()
    {
        return emp_data;
    }

    public void GetEmpDetails(Emp_data emp)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"► Employee Name: {emp.Emp_name}");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"  Employee ID: {emp.Emp_id}");
        Console.WriteLine($"  Address: {emp.Emp_address}");
        Console.WriteLine($"  Email: {emp.Emp_email}");
        Console.WriteLine($"  Phone: {emp.Emp_phone}");
    }

}