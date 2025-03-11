using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Email
{
    public class EmailValidator
    {
        public bool IsValidEmail(string email)
        {
            /*if (string.IsNullOrEmpty(email)) return false;
            int atIndex = email.IndexOf("@");
            if (atIndex <= 0 || atIndex != email.LastIndexOf("@")) return false;
            string localPart = email.Substring(0, atIndex);
            string domainPart = email.Substring(atIndex + 1);
            if (string.IsNullOrEmpty(domainPart) || string.IsNullOrEmpty(localPart)) return false;
            int dotIndex = domainPart.IndexOf('.');
            if (dotIndex <= 0 || dotIndex == domainPart.Length - 1) return false;
            return true;*/
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            var validator = new EmailValidator();
            Console.Write("Add meg az emailedet: ");
            string email = Console.ReadLine();
            Console.WriteLine(validator.IsValidEmail(email) ? "Helyes e-mail!" : "Helytelen e-mail!"); 
            Console.ReadKey();
        }
    }
}