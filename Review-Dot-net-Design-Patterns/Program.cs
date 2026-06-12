// See https://aka.ms/new-console-template for more information

using Review_Dot_net_Design_Patterns;
using Review_Dot_net_Design_Patterns.model;

// Set console background to black
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;
Console.Clear();

// Add title
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
Console.WriteLine("║         EMPLOYEE MANAGEMENT SYSTEM - DATA ENTRY            ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.White;
Emp_method emp_method = new Emp_method(0, "", "", "", "");
emp_method.readEmpDetails();

// Display separator
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n╔════════════════════════════════════════════════════════════╗");
Console.WriteLine("║              EMPLOYEE INFORMATION DISPLAY                  ║");
Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"Date/Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.White;
emp_method.GetEmpDetails(emp_method.GetEmpData());

Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("\n╚════════════════════════════════════════════════════════════╝");
Console.ResetColor();

