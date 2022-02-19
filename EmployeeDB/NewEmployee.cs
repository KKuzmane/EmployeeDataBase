using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    public class NewEmployee
    {
        private static string _firstName;
        private static string _lastName;
        private static string _phone;
        private static string _email;
        private static string _country;
        private static string _employeeID;
        private static string _inTraining;
        private static string _department;
        private static string _position;
        private static string _hiredAt;
        private static string _terminatedAt;

        public NewEmployee(string firstName, string lastName, string phone, string email, string country, string employeeId, string inTraining, string department, string position, string hiredAt, string terminatedAt)
        {
            _firstName = firstName;
            _lastName = lastName;
            _phone = phone;
            _email = email;
            _country = country;
            _employeeID = employeeId;
            _inTraining = inTraining;
            _department = department;
            _position = position;
            _hiredAt = hiredAt;
            _terminatedAt = terminatedAt;
        }

        public string[] GetEmployee()
        {
            string[] employee = new string[] { _firstName, _lastName, _phone, _email, _country, _employeeID, _inTraining, _department, _position, _hiredAt, _terminatedAt}; 
            
            return employee;
        }
    }
}