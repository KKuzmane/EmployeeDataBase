using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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