using System;
using System.Data.SqlClient;

namespace FirmDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(local);Initial Catalog=TEST2;Integrated Security=True";

            InsertProduct(connectionString, 1001, "Ручка, свежая)", 1, 50.00m);

            InsertProductType(connectionString, 4, "Химикалии");

            InsertSalesManager(connectionString, 3, "Сидоров Сидор Сидорович", "001");

            InsertCustomer(connectionString, 3, "ХеХ 'Пример'", "г. Пример, ул. Примерная, д. 1");

            Console.WriteLine("Данные успешно добавлены!");
        }

        static void InsertProduct(string connectionString, int productId, string productName, int productType, decimal price)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (ProductID, ProductName, ProductType, Price) " +
                               "VALUES (@ProductID, @ProductName, @ProductType, @Price)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@ProductType", productType);
                command.Parameters.AddWithValue("@Price", price);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static void InsertProductType(string connectionString, int typeId, string typeName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ProductTypes (TypeID, TypeName) " +
                               "VALUES (@TypeID, @TypeName)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TypeID", typeId);
                command.Parameters.AddWithValue("@TypeName", typeName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static void InsertSalesManager(string connectionString, int managerId, string managerName, string managerPhone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO SalesManagers (ManagerID, ManagerName, ManagerPhone) " +
                               "VALUES (@ManagerID, @ManagerName, @ManagerPhone)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ManagerID", managerId);
                command.Parameters.AddWithValue("@ManagerName", managerName);
                command.Parameters.AddWithValue("@ManagerPhone", managerPhone);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        static void InsertCustomer(string connectionString, int customerId, string customerName, string customerAddress)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (CustomerID, CustomerName, CustomerAddress) " +
                               "VALUES (@CustomerID, @CustomerName, @CustomerAddress)";

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
