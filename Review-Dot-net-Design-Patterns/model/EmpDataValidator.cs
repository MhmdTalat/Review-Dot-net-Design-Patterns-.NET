using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Review_Dot_net_Design_Patterns.model
{
    public class EmpDataValidator
    {
        /// <summary>
        /// Validates all employee data fields
        /// </summary>
        /// <param name="empData">Employee data to validate</param>
        /// <returns>Dictionary with field names and error messages</returns>
        public static Dictionary<string, string> ValidateEmpData(Emp_data empData)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            // Validate Employee ID
            if (!ValidateEmpId(empData.Emp_id))
            {
                errors.Add("Emp_id", "Employee ID must be a positive number greater than 0");
            }

            // Validate Employee Name
            string? nameError = ValidateEmpName(empData.Emp_name);
            if (nameError != null)
            {
                errors.Add("Emp_name", nameError);
            }

            // Validate Employee Address
            string? addressError = ValidateEmpAddress(empData.Emp_address);
            if (addressError != null)
            {
                errors.Add("Emp_address", addressError);
            }

            // Validate Employee Email
            string? emailError = ValidateEmpEmail(empData.Emp_email);
            if (emailError != null)
            {
                errors.Add("Emp_email", emailError);
            }

            // Validate Employee Phone
            string? phoneError = ValidateEmpPhone(empData.Emp_phone);
            if (phoneError != null)
            {
                errors.Add("Emp_phone", phoneError);
            }

            return errors;
        }

        /// <summary>
        /// Validates Employee ID
        /// </summary>
        public static bool ValidateEmpId(int empId)
        {
            return empId > 0;
        }

        /// <summary>
        /// Validates Employee Name
        /// </summary>
        public static string? ValidateEmpName(string? empName)
        {
            if (string.IsNullOrWhiteSpace(empName))
            {
                return "Employee Name cannot be empty";
            }

            if (empName.Length < 2)
            {
                return "Employee Name must be at least 2 characters long";
            }

            if (empName.Length > 50)
            {
                return "Employee Name cannot exceed 50 characters";
            }

            if (!Regex.IsMatch(empName, @"^[a-zA-Z\s'-]+$"))
            {
                return "Employee Name can only contain letters, spaces, hyphens, and apostrophes";
            }

            return null;
        }

        /// <summary>
        /// Validates Employee Address
        /// </summary>
        public static string? ValidateEmpAddress(string? address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return "Address cannot be empty";
            }

            if (address.Length < 5)
            {
                return "Address must be at least 5 characters long";
            }

            if (address.Length > 100)
            {
                return "Address cannot exceed 100 characters";
            }

            return null;
        }

        /// <summary>
        /// Validates Employee Email
        /// </summary>
        public static string? ValidateEmpEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return "Email cannot be empty";
            }

            // Basic email validation using regex
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                return "Email format is invalid. Please enter a valid email (e.g., user@example.com)";
            }

            if (email.Length > 100)
            {
                return "Email cannot exceed 100 characters";
            }

            return null;
        }

        /// <summary>
        /// Validates Employee Phone
        /// </summary>
        public static string? ValidateEmpPhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return "Phone number cannot be empty";
            }

            // Remove common phone separators for validation
            string cleanPhone = Regex.Replace(phone, @"[\s\-\(\)\.+]", "");

            if (cleanPhone.Length < 10)
            {
                return "Phone number must have at least 10 digits";
            }

            if (cleanPhone.Length > 15)
            {
                return "Phone number cannot exceed 15 digits";
            }

            if (!Regex.IsMatch(cleanPhone, @"^\d+$"))
            {
                return "Phone number can only contain digits, spaces, hyphens, and parentheses";
            }

            return null;
        }

        /// <summary>
        /// Displays validation errors to console
        /// </summary>
        public static void DisplayValidationErrors(Dictionary<string, string> errors)
        {
            if (errors.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✓ All fields are valid!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n✗ Validation Errors Found:");
            Console.WriteLine(new string('-', 50));
            foreach (var error in errors)
            {
                Console.WriteLine($"  • {error.Key}: {error.Value}");
            }
            Console.WriteLine(new string('-', 50));
            Console.ResetColor();
        }
    }
}
