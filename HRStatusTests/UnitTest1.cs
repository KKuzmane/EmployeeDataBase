using EmployeeDB;
using NUnit.Framework;

namespace HRStatusTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddHRStatus_TerminatedAtDate_ReturnsTerminated()
        {
            string terminatedAt = "05-21-2020";
            string inTraining = "Yes";

            string status = Add_HR_Status.FillHRStatusColumn(terminatedAt, inTraining);

            Assert.AreEqual("Terminated", status);
        }

        [Test]
        public void AddHRStatus_InTraining_ReturnsInTraining()
        {
            string terminatedAt = "";
            string inTraining = "Yes";

            string status = Add_HR_Status.FillHRStatusColumn(terminatedAt, inTraining);

            Assert.AreEqual("In Training", status);
        }

        [Test]
        public void AddHRStatus_NoTerminationDateAndNoTraining_ReturnsActive()
        {
            string terminatedAt = "";
            string inTraining = "No";

            string status = Add_HR_Status.FillHRStatusColumn(terminatedAt, inTraining);

            Assert.AreEqual("Active", status);
        }
    }
}