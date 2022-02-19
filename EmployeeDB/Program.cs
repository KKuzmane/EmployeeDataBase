using System.Data.SQLite;

namespace EmployeeDB
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection sqlite_conn = CreateDB.CreateConnection();

            if (!CreateDB.TableExists(sqlite_conn))
            {
                CreateDB.CreateDbTable(sqlite_conn);
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