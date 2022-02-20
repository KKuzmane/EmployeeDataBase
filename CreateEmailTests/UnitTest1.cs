using NUnit.Framework;

namespace CreateEmailTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddHRStatus_InTraining_ReturnsInTraining()
        {
            string firstName = "Kristine";
            string lastName = "Kuzmane";

            string email = EmployeeDB.CreateEmail.CreateCompanyEmail(firstName, lastName);

            Assert.AreEqual("kkuzmane@ibsat.com", email);
        }
    }
}