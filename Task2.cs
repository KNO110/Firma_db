using System;
using System.Data.SqlClient;

namespace FirmDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(local);Initial Catalog=TEST2;Integrated Security=True";

            UpdateProduct(connectionString, 1001, "Пример", 1, 75.00m);

            UpdateProductType(connectionString, 4, "Хим товары");

            UpdateSalesManager(connectionString, 3, "Вася пупкин", "+8888888888");

            UpdateCustomer(connectionString, 3, "ОДА 'Чё-то'", "г. Новый, ул. Новая, д. 1");

            Console.WriteLine("Данные успешно обновлены!");
        }

        static void UpdateProduct(string connectionString, int productId, string productName, int productType, decimal price)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products " +
                               "SET ProductName = @ProductName, ProductType = @ProductType, Price = @Price " +
                               "WHERE ProductID = @ProductID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@ProductType", productType);
                command.Parameters.AddWithValue("@Price", price);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static void UpdateProductType(string connectionString, int typeId, string typeName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ProductTypes " +
                               "SET TypeName = @TypeName " +
                               "WHERE TypeID = @TypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TypeID", typeId);
                command.Parameters.AddWithValue("@TypeName", typeName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static void UpdateSalesManager(string connectionString, int managerId, string managerName, string managerPhone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE SalesManagers " +
                               "SET ManagerName = @ManagerName, ManagerPhone = @ManagerPhone " +
                               "WHERE ManagerID = @ManagerID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ManagerID", managerId);
                command.Parameters.AddWithValue("@ManagerName", managerName);
                command.Parameters.AddWithValue("@ManagerPhone", managerPhone);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static void UpdateCustomer(string connectionString, int customerId, string customerName, string customerAddress)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customers " +
                               "SET CustomerName = @CustomerName, CustomerAddress = @CustomerAddress " +
                               "WHERE CustomerID = @CustomerID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);
                command.Parameters.AddWithValue("@CustomerName", customerName);
                command.Parameters.AddWithValue("@CustomerAddress", customerAddress);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
