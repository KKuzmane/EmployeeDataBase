using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    class Program
    {
        static void Main(string[] args)
        {
            List<NewEmployee> employees = new List<NewEmployee>();

            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateDB.CreateConnection();

            if (!CreateDB.TableExists(sqlite_conn))
            {
                CreateDB.CreateTable(sqlite_conn);

                using (var reader =
                       new StreamReader(@"C:\Users\krist\Desktop\06-2021\EmployeeDataBase\EmployeeDataTest.csv"))
                {
                    string headerLine = reader.ReadLine();
                    string newLine;
                    while ((newLine = reader.ReadLine()) != null)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        var status = Add_HR_Status.FillHRStatusColumn(values[10], values[6]);
                        var email = CreateEmail.CreateCompanyEmail(values[0], values[1]);

                        var employee = new NewEmployee(values[0], values[1], values[2], values[3], values[4], values[5],
                            values[6], values[7], values[8], values[9], values[10]);

                        CreateDB.InsertData(sqlite_conn, employee, status, email);

                        employees.Add(employee);
                    }
                }
            }

            string searchAgain = "y";

            while (searchAgain != "n")
            {
                if (searchAgain == "y")
                {
                    FindEmployee.SearchEngine(sqlite_conn);
                    Console.WriteLine();
                    Console.WriteLine("Do You want to search another employee y/n?");
                    searchAgain = Console.ReadLine();
                }
                else if (searchAgain == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input. Try again.");
                    searchAgain = Console.ReadLine();
                }
            }
        }
    }
}