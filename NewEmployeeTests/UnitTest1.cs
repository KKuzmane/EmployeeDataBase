using EmployeeDB;
using NUnit.Framework;

namespace NewEmployeeTests
{
    public class Tests
    {
        private static string _firstName = "Kristine";
        private static string _lastName = "Kuzmane";
        private static string _phone = "26577489";
        private static string _email = "kristinekuzmane@gmail.com";
        private static string _country = "Latvia";
        private static string _employeeID = "2105";
        private static string _inTraining = "No";
        private static string _department = "Home";
        private static string _position = "Developer";
        private static string _hiredAt = "24.02.2022.";
        private static string _terminatedAt = "";

        private NewEmployee _target;

        [SetUp]
        public void Setup()
        {
            _target = new NewEmployee(_firstName, _lastName, _phone, _email, _country, _employeeID, _inTraining, _department, _position, _hiredAt, _terminatedAt);
        }

        [Test]
        public void NewEmployee_AddEmployeeData_ReturnEmployeeArray()
        {
            string[] employee = _target.GetEmployee();
            
            string[] expected = { "Kristine", "Kuzmane", "26577489", "kristinekuzmane@gmail.com", "Latvia", "2105", "No", "Home", "Developer", "24.02.2022.", "" };

            Assert.AreEqual(expected, employee);
        }
    }
}