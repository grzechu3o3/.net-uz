using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        if(args.Length == 0)
        {
            Console.Error.WriteLine("Wrong usage: try Zadanie_02.exe IP-ADDRESS or Zadanie_02.exe mail@example.com");
            return;
        } else
        {
            string verified_string = args[0];
            string ip_pattern = "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            string email_pattern = @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$";

            if (Regex.IsMatch(verified_string, ip_pattern)) {
                Console.WriteLine("Given string: " + verified_string + " is a valid IP address!");
            } else
            {
                Console.WriteLine("Entered string: " + verified_string + " isn't a valid IP address");
            }

            if (Regex.IsMatch(verified_string, email_pattern))
            {
                Console.WriteLine("Given string: " + verified_string + " is a valid email address!");
            } else
            {
                Console.WriteLine("Entered string: " + verified_string + " isn't a valid email address");
            }

        }
    }
}
