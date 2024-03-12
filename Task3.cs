using System;
using System.Data.SqlClient;

namespace FirmDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(local);Initial Catalog=TEST2;Integrated Security=True";

            DeleteProduct(connectionString, 1001);

            DeleteSalesManager(connectionString, 3);

            DeleteProductType(connectionString, 4);

            DeleteCustomer(connectionString, 3);

            Console.WriteLine("Данные успешно удалены и перемещены в архивные таблицы!");
        }

        static void DeleteProduct(string connectionString, int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Перенос данных
                string archiveQuery = "INSERT INTO ArchivedProducts SELECT * FROM Products WHERE ProductID = @ProductID";

                // Удаление данных из основной таблицы
                string deleteQuery = "DELETE FROM Products WHERE ProductID = @ProductID";

                SqlCommand archiveCommand = new SqlCommand(archiveQuery, connection);
                archiveCommand.Parameters.AddWithValue("@ProductID", productId);

                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@ProductID", productId);

                connection.Open();
                archiveCommand.ExecuteNonQuery();
                deleteCommand.ExecuteNonQuery();
            }
        }

        static void DeleteProductType(string connectionString, int typeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Перенос
                string archiveQuery = "INSERT INTO ArchivedProductTypes SELECT * FROM ProductTypes WHERE TypeID = @TypeID";

                // Удаление
                string deleteQuery = "DELETE FROM ProductTypes WHERE TypeID = @TypeID";

                SqlCommand archiveCommand = new SqlCommand(archiveQuery, connection);
                archiveCommand.Parameters.AddWithValue("@TypeID", typeId);

                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@TypeID", typeId);

                connection.Open();
                archiveCommand.ExecuteNonQuery();
                deleteCommand.ExecuteNonQuery();
            }
        }

        static void DeleteSalesManager(string connectionString, int managerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Перенос
                string archiveQuery = "INSERT INTO ArchivedSalesManagers SELECT * FROM SalesManagers WHERE ManagerID = @ManagerID";

                // Удаление
                string deleteQuery = "DELETE FROM SalesManagers WHERE ManagerID = @ManagerID";

                SqlCommand archiveCommand = new SqlCommand(archiveQuery, connection);
                archiveCommand.Parameters.AddWithValue("@ManagerID", managerId);

                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@ManagerID", managerId);

                connection.Open();
                archiveCommand.ExecuteNonQuery();
                deleteCommand.ExecuteNonQuery();
            }
        }

        static void DeleteCustomer(string connectionString, int customerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Перенос
                string archiveQuery = "INSERT INTO ArchivedCustomers SELECT * FROM Customers WHERE CustomerID = @CustomerID";

                // Удаление
                string deleteQuery = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                SqlCommand archiveCommand = new SqlCommand(archiveQuery, connection);
                archiveCommand.Parameters.AddWithValue("@CustomerID", customerId);

                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@CustomerID", customerId);

                connection.Open();
                archiveCommand.ExecuteNonQuery();
                deleteCommand.ExecuteNonQuery();
            }
        }
    }
}
