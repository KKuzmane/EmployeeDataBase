using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace EmployeeDB
{
    public class CreateDB
    {
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source= DB.db; Version = 3; New = True; Compress = True; "); 

            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        public static void CreateTable(SQLiteConnection conn)
        {
            string Createsql = $"CREATE TABLE Employees (FirstName TEXT, LastName TEXT, Phone TEXT, Email TEXT, Country TEXT, EmployeeID INTEGER, " +
                               $"InTraining TEXT, Department TEXT, Position TEXT, HiredAt TEXT, TerminatedAt TEXT, HRStatus TEXT, CompanyEmail TEXT)";
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void InsertData(SQLiteConnection conn, NewEmployee employee, string status, string email)
        {
            string[] getData = employee.GetEmployee();
            
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Employees (FirstName, LastName, Phone, Email, Country, EmployeeID, " +
                                     "InTraining, Department, Position, HiredAt, TerminatedAt, HRStatus, CompanyEmail) " +
                                     $"VALUES('{getData[0]}', '{getData[1]}', '{getData[2]}', '{getData[3]}', '{getData[4]}', " +
                                     $"'{getData[5]}', '{getData[6]}', '{getData[7]}', '{getData[8]}', " +
                                     $"'{getData[9]}', '{getData[10]}', '{status}', '{email}');";
            sqlite_cmd.ExecuteNonQuery();
        }

        public static Boolean TableExists(SQLiteConnection connection)
        {
            SQLiteCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM sqlite_master WHERE type = 'table' AND name = @name";
            cmd.Parameters.Add("@name", DbType.String).Value = "Employees";
            return (cmd.ExecuteScalar() != null);
        }

        public static void CreateDbTable(SQLiteConnection connection)
        {
            CreateDB.CreateTable(connection);

            using (var reader =
                   new StreamReader(@"./EmployeeDataTestCSVFile/EmployeeDataTest.csv"))
            {
                string headerLine = reader.ReadLine();
                string newLine;
                while ((newLine = reader.ReadLine()) != null)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    var status = Add_HR_Status.FillHRStatusColumn(values[10], values[6]);
                    var email = CreateEmail.CreateCompanyEmail(values[0], values[1]);

                    string hiredDate = Regex.Replace(values[9], @"[^0-9a-zA-Z]+", "-");
                    string terminatedDate = Regex.Replace(values[10], @"[^0-9a-zA-Z]+", "-");

                    var employee = new NewEmployee(values[0], values[1], values[2], values[3], values[4], values[5],
                        values[6], values[7], values[8], hiredDate, terminatedDate);

                    CreateDB.InsertData(connection, employee, status, email);
                }
            }
        }
    }
}