using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Benchmark
{
    public class AppTableCreatingTool
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;

        public AppTableCreatingTool(string connectionString)
        {
            _connectionString = connectionString;
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public void CreateMainTable()
        {
            try
            {
                _sqlConnection.Open();

                string query = @"CREATE TABLE Tests(
	                            Id INT IDENTITY(1,1) PRIMARY KEY,
	                            Value1 INT NOT NULL,
	                            Value2 INT NOT NULL,
	                            Value3 INT NOT NULL,
	                            Value4 INT NOT NULL,
	                            Value5 INT NOT NULL
                            )";

                SqlCommand command = new SqlCommand(query, _sqlConnection);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                // Table already exists
            }
            finally
            {
                _sqlConnection.Close();
            }
        }


        public void CreateResultsTable()
        {
            try
            {
                _sqlConnection.Open();

                string query = @"CREATE TABLE Results(
	                                Id INT IDENTITY(1,1) PRIMARY KEY,
	                                Resolver NVARCHAR(50) NOT NULL,
	                                Timing BIGINT NOT NULL
                                )";

                SqlCommand command = new SqlCommand(query, _sqlConnection);

                command.ExecuteNonQuery();

                _sqlConnection.Close();
            }
            catch (Exception)
            {
                // Table already exists
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

    }
}
