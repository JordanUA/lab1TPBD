using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=AdsDB;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Connection established.");

            // Викликаємо методи для демонстрації роботи з базою даних
            ShowUsers(connection);
            AddUser(connection, "Alice Johnson", "alice.johnson@example.com", "5678912345");
            ShowAdsWithUser(connection);
            ShowAdsByPrice(connection, 100);
            ShowAveragePrice(connection);
        }
    }

    // Метод для відображення користувачів
    static void ShowUsers(SqlConnection connection)
    {
        string query = "SELECT * FROM Users";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ID"]}: {reader["Name"]}, {reader["Email"]}, {reader["Phone"]}");
                }
            }
        }
    }

    // Метод для додавання нового користувача
    static void AddUser(SqlConnection connection, string name, string email, string phone)
    {
        string query = "INSERT INTO Users (Name, Email, Phone, RegistrationDate) VALUES (@Name, @Email, @Phone, @RegistrationDate)";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);

            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} row(s) inserted.");
        }
    }

    // Метод для відображення оголошень з іменами користувачів
    static void ShowAdsWithUser(SqlConnection connection)
    {
        string query = "SELECT Ads.Title, Ads.Description, Users.Name FROM Ads " +
                       "JOIN Users ON Ads.UserID = Users.ID";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Title"]}: {reader["Description"]} by {reader["Name"]}");
                }
            }
        }
    }

    // Метод для відображення оголошень за ціною більше заданої
    static void ShowAdsByPrice(SqlConnection connection, decimal price)
    {
        string query = "SELECT * FROM Ads WHERE Price > @Price";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Price", price);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Title"]}: {reader["Price"]}");
                }
            }
        }
    }

    // Метод для відображення середньої ціни оголошень
    static void ShowAveragePrice(SqlConnection connection)
    {
        string query = "SELECT AVG(Price) AS AveragePrice FROM Ads";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            object result = command.ExecuteScalar();
            Console.WriteLine($"Average Price: {result}");
        }
    }
}
