using Domain.Model;
using Domain.RepositoryInterface;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepo : IProductRepo
    {
        private DbConnectionAdo db = new DbConnectionAdo();
        public async Task<bool> AddProductAsync(Product product)
        {
            // Using a parameterized query to prevent SQL injection
            string query = "INSERT INTO Product (ProductName,ProductFile, ProductType, ProductSize, Quantity, NumberOfOrders) " +
                           "VALUES (@ProductName,@ProductFile, @ProductType, @ProductSize, @Quantity, @NumberOfOrders)";

            // Create a SQL command and set parameters
            SqlCommand cmd = new SqlCommand(query, db.cnn);

            // Add parameters and their corresponding values
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ProductFile", product.ProductFile ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ProductType", product.ProductType ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ProductSize", product.ProductSize ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@NumberOfOrders", product.NumberOfOrders);

            // Open the connection if it's closed
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();

            // Execute the query asynchronously
            int rowsAffected = await cmd.ExecuteNonQueryAsync();

            // Close the connection
            db.cnn.Close();

            // Return true if one or more rows were affected (indicating the insert was successful)
            return rowsAffected > 0;
        }

        public async Task<bool> DeletedAsync(int Id)
        {
            // Using a parameterized query to prevent SQL injection
            string query = "DELETE FROM Product WHERE Id = @Id";

            // Create the SQL command and add the parameter
            SqlCommand cmd = new SqlCommand(query, db.cnn);

            // Add the Id parameter
            cmd.Parameters.AddWithValue("@Id", Id);

            // Open the connection if it's closed
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();

            // Execute the query asynchronously
            int rowsAffected = await cmd.ExecuteNonQueryAsync();

            // Close the connection
            db.cnn.Close();

            // Return true if one or more rows were affected (i.e., the delete was successful)
            return rowsAffected > 0;
        }


        public async Task<bool> EditProductAsync(Product product)
        {
            // Using parameterized queries to prevent SQL injection
            string query = "UPDATE Product SET " +
                "ProductName = @ProductName, " +
                "ProductFile = @ProductFile, " +
                "ProductType = @ProductType, " +
                "ProductSize = @ProductSize, " +
                "Quantity = @Quantity, " +
                "NumberOfOrders = @NumberOfOrders " +
                "WHERE Id = @Id";

            // Create the SQL command and add parameters
            SqlCommand cmd = new SqlCommand(query, db.cnn);

            // Add parameters to the command
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ProductFile", product.ProductFile ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ProductType", product.ProductType ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@ProductSize", product.ProductSize ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@NumberOfOrders", product.NumberOfOrders);
            cmd.Parameters.AddWithValue("@Id", product.Id);

            // Open the connection if it's closed
            if (db.cnn.State == System.Data.ConnectionState.Closed)
                db.cnn.Open();

            // Execute the query
            int rowsAffected = await cmd.ExecuteNonQueryAsync();

            // Close the connection
            db.cnn.Close();

            // Return true if at least one row was affected (i.e., the update was successful)
            return rowsAffected > 0;
        }


        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            string query = "SELECT * FROM Product";

            // Use a 'using' statement to ensure proper disposal of resources
            using (SqlCommand sqlCommand = new SqlCommand(query, db.cnn))
            {
                // Open the connection if it's closed
                if (db.cnn.State == System.Data.ConnectionState.Closed)
                    await db.cnn.OpenAsync();

                // Execute the query asynchronously
                using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                {
                    List<Product> products = new List<Product>();

                    // Read the data asynchronously
                    while (await sqlDataReader.ReadAsync())
                    {
                        Product product = new Product
                        {
                            Id = (int)sqlDataReader["Id"],
                            ProductName = sqlDataReader["ProductName"].ToString(),
                            ProductFile = sqlDataReader["ProductFile"].ToString(),
                            ProductType = sqlDataReader["ProductType"].ToString(),
                            ProductSize = (decimal)sqlDataReader["ProductSize"],
                            Quantity = (decimal)sqlDataReader["Quantity"],
                            NumberOfOrders = (int)sqlDataReader["NumberOfOrders"]
                        };

                        products.Add(product);
                    }

                    return products;
                }
            }
        }


        public async Task<Product> GetProductByIdAsync(int Id)
        {
            // Define the query with parameterized input to prevent SQL injection
            string query = "SELECT * FROM Product WHERE Id = @Id";

            // Create the SQL command and add the parameter
            using (SqlCommand sqlCommand = new SqlCommand(query, db.cnn))
            {
                // Add the parameter value
                sqlCommand.Parameters.AddWithValue("@Id", Id);

                // Open the connection if it's closed
                if (db.cnn.State == System.Data.ConnectionState.Closed)
                    await db.cnn.OpenAsync();

                // Execute the query asynchronously
                using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                {
                    // Check if any data is returned
                    if (await sqlDataReader.ReadAsync())
                    {
                        // Map the data to the Product object
                        Product product = new Product
                        {
                            Id = (int)sqlDataReader["Id"],
                            ProductName = sqlDataReader["ProductName"].ToString(),
                            ProductFile = sqlDataReader["ProductFile"].ToString(),
                            ProductType = sqlDataReader["ProductType"].ToString(),
                            ProductSize = (decimal)sqlDataReader["ProductSize"],
                            Quantity = (decimal)sqlDataReader["Quantity"],
                            NumberOfOrders = (int)sqlDataReader["NumberOfOrders"]
                        };

                        return product;
                    }
                    else
                    {
                        // Return null if no data is found for the given Id
                        return null;
                    }
                }
            }
        }


    }
}
