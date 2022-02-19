using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDB
{
    public class CreateDB
    {
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source= DB.db; Version = 3; New = True; Compress = True; "); 

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
            SQLiteCommand sqlite_cmd;
            string Createsql = $"CREATE TABLE Employees (FirstName TEXT, LastName TEXT, Phone TEXT, Email TEXT, Country TEXT, EmployeeID INTEGER, " +
                               $"InTraining TEXT, Department TEXT, Position TEXT, HiredAt TEXT, TerminatedAt TEXT, HRStatus TEXT, CompanyEmail TEXT)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();
        }

        public static void InsertData(SQLiteConnection conn, NewEmployee employee, string status, string email)
        {
            string[] getData = employee.GetEmployee();

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
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
    }
}