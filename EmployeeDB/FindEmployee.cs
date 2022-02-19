using System.Data.SQLite;

namespace EmployeeDB
{
    public class FindEmployee
    {
        public static void SearchEngine(SQLiteConnection conn)
        {
            Console.WriteLine("Enter employees entering partial email or partial first name or partial last name");
            string input = Console.ReadLine();

            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = $"SELECT * FROM Employees WHERE FirstName LIKE '%{input}%' OR LastName LIKE '%{input}%' " +
                                     $"OR Email LIKE '%{input}%' LIMIT 5;";
            using SQLiteDataReader reader = sqlite_cmd.ExecuteReader();

            if (reader.HasRows)
            {
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    if (i == 12)
                    {
                        Console.Write(reader.GetName(i));
                    }
                    else
                    {
                        Console.Write(reader.GetName(i) + ", ");
                    }
                }

                Console.WriteLine();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (i == 12)
                        {
                            Console.Write(reader.GetValue(i));
                        }
                        else
                        {
                            Console.Write(reader.GetValue(i) + ", ");
                        }
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
        }
    }
}