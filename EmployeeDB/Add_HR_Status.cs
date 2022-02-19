namespace EmployeeDB
{
    public class Add_HR_Status
    {
        public static string FillHRStatusColumn(string terminatedAt, string inTraining)
        {
            string status;

            if (terminatedAt != "")
            {
                status = "Terminated";
            }
            else if (inTraining == "Yes")
            {
                status = "InTraining";
            }
            else
            {
                status = "Active";
            }

            return status;
        }
    }
}