using System;
using System.Data;
using System.Data.SqlClient;

namespace FirmDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(local);Initial Catalog=TEST2;Integrated Security=True";

            ShowManagerWithMostUnitsSold(connectionString);

            ShowManagerWithHighestProfit(connectionString);

            DateTime startDate = new DateTime(2024, 1, 1);
            DateTime endDate = new DateTime(2024, 3, 1);
            ShowManagerWithHighestProfitInRange(connectionString, startDate, endDate);

            ShowCustomerWithHighestTotalPurchase(connectionString);

            ShowProductTypeWithMostUnitsSold(connectionString);

            ShowMostProfitableProductType(connectionString);


            ShowMostPopularProducts(connectionString);

            int daysThreshold = 30;
            ShowProductsNotSoldForDays(connectionString, daysThreshold);
        }

        static void ShowManagerWithMostUnitsSold(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 ManagerID, SUM(Quantity) AS TotalUnitsSold " +
                               "FROM Sales " +
                               "GROUP BY ManagerID " +
                               "ORDER BY TotalUnitsSold DESC";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int managerId = reader.GetInt32(0);
                    int totalUnitsSold = reader.GetInt32(1);

                    Console.WriteLine($"Менеджер с ID {managerId} имеет наибольшее количество продаж: {totalUnitsSold} единиц.");
                }
                reader.Close();
            }
        }

        static void ShowManagerWithHighestProfit(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 ManagerID, SUM(Price * Quantity) AS TotalProfit " +
                               "FROM Sales " +
                               "GROUP BY ManagerID " +
                               "ORDER BY TotalProfit DESC";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int managerId = reader.GetInt32(0);
                    decimal totalProfit = reader.GetDecimal(1);

                    Console.WriteLine($"Менеджер с ID {managerId} имеет наибольшую общую прибыль: {totalProfit:C2}.");
                }
                reader.Close();
            }
        }
        /// powered by ak1ne

        static void ShowManagerWithHighestProfitInRange(string connectionString, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 ManagerID, SUM(Price * Quantity) AS TotalProfit " +
                               "FROM Sales " +
                               "WHERE SaleDate BETWEEN @StartDate AND @EndDate " +
                               "GROUP BY ManagerID " +
                               "ORDER BY TotalProfit DESC";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int managerId = reader.GetInt32(0);
                    decimal totalProfit = reader.GetDecimal(1);

                    Console.WriteLine($"Менеджер с ID {managerId} имеет наибольшую общую прибыль за период с {startDate:d} по {endDate:d}: {totalProfit:C2}.");
                }
                reader.Close();
            }
        }

        static void ShowCustomerWithHighestTotalPurchase(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 CustomerID, SUM(Price * Quantity) AS TotalPurchase " +
                               "FROM Sales " +
                               "GROUP BY CustomerID " +
                               "ORDER BY TotalPurchase DESC";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int customerId = reader.GetInt32(0);
                    decimal totalPurchase = reader.GetDecimal(1);

                    Console.WriteLine($"Фирма покупатель с ID {customerId} совершила самую большую суммарную покупку: {totalPurchase:C2}.");
                }
                reader.Close();
            }
        }

        static void ShowProductTypeWithMostUnitsSold(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 ProductType, SUM(Quantity) AS TotalUnitsSold " +
                               "FROM Sales " +
                               "GROUP BY ProductType " +
                               "ORDER BY TotalUnitsSold DESC";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int productType = reader.GetInt32(0);
                    int totalUnitsSold = reader.GetInt32(1);

                    Console.WriteLine($"Тип канцтоваров с ID {productType} имеет наибольшее количество продаж: {totalUnitsSold} единиц.");
                }
                reader.Close();
            }
        }

        static void ShowMostProfitableProductType(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 ProductType, SUM(Price * Quantity) AS TotalProfit " +
                               "FROM Sales " +
                               "GROUP BY ProductType " +
                               "ORDER BY TotalProfit DESC";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int productType = reader.GetInt32(0);
                    decimal totalProfit = reader.GetDecimal(1);

                    Console.WriteLine($"Самый прибыльный тип канцтоваров с ID {productType} имеет общую прибыль: {totalProfit:C2}.");
                }
                reader.Close();
            }
        }

        static void ShowMostPopularProducts(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TOP 1 ProductName, SUM(Quantity) AS TotalUnitsSold " +
                               "FROM Sales " +
                               "GROUP BY ProductName " +
                               "ORDER BY TotalUnitsSold DESC";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string productName = reader.GetString(0);
                    int totalUnitsSold = reader.GetInt32(1);

                    Console.WriteLine($"Самый популярный канцтовар '{productName}' был продан в количестве: {totalUnitsSold} единиц.");
                }
                reader.Close();
            }
        }
        ///// powered by ak1ne

        static void ShowProductsNotSoldForDays(string connectionString, int daysThreshold)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ProductName " +
                               "FROM Products " +
                               "WHERE ProductID NOT IN (SELECT ProductID FROM Sales WHERE DATEDIFF(day, SaleDate, GETDATE()) <= @DaysThreshold)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DaysThreshold", daysThreshold);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine($"Канцтовары, которые не продавались в течение последних {daysThreshold} дней:");
                while (reader.Read())
                {
                    string productName = reader.GetString(0);
                    Console.WriteLine(productName);
                }
                reader.Close();
            }
        }
    }
}
