using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Password
{
    public class PasswordValidator
    {
        public bool isValidPassword(string password)
        {
            /*if(string.IsNullOrEmpty(password)) return false; //ne lgyen null vagy empty
            if(password.Length < 8) return false; //legyen legalább 8 karakter
            if (!password.Any(char.IsDigit)) return false; //tartalmazzon számot
            if (!password.Any(karakter => !Char.IsLetterOrDigit(karakter))) return false; //legalább 1 speckó karakter
            return true;*/

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            {
                return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            var validator = new PasswordValidator();
            Console.Write("Add meg a jelszavadat: ");
            string pass = Console.ReadLine();
            Console.WriteLine(validator.isValidPassword(pass) ? "Helyes jelszó!" : "Helytelen jelszó!");
            Console.ReadKey();
        }
    }
}
