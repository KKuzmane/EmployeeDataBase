using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    public static class CreateEmail
    {
        public static string CreateCompanyEmail(string firstName, string lastName)
        {
            char[] letters = firstName.ToLower().ToCharArray();
            char firstLetter = letters[0];

            string email = $"{firstLetter}{lastName.ToLower()}@ibsat.com";

            return email;
        }
    }
}