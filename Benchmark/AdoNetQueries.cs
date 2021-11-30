using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;

namespace Benchmark
{
    class AdoNetQueries
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;

        public AdoNetQueries(string connectionString)
        {
            _connectionString = connectionString;
            _sqlConnection = new SqlConnection(_connectionString);
        }


        public long Insert1000Values()
        {
            try
            {
                _sqlConnection.Open();

                Random rnd = new Random();
                Stopwatch stopwatch = new Stopwatch();
                SqlCommand command;
                stopwatch.Start();
                for (int i = 0; i < 1000; i++)
                {
                    string query = $"INSERT INTO Tests(Value1, Value2, Value3, Value4, Value5) VALUES({rnd.Next(1, 11)}, {rnd.Next(1, 11)}, {rnd.Next(1, 11)}, {rnd.Next(1, 11)}, {rnd.Next(1, 11)})";
                    command = new SqlCommand(query, _sqlConnection);
                    command.ExecuteNonQuery();
                }
                stopwatch.Stop();

                _sqlConnection.Close();

                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return 0;
        }

        public long Insert1Values()
        {
            try
            {
                _sqlConnection.Open();

                Random rnd = new Random();
                Stopwatch stopwatch = new Stopwatch();
                SqlCommand command;
                stopwatch.Start();

                string query = $"INSERT INTO Tests(Value1, Value2, Value3, Value4, Value5) VALUES({rnd.Next(1, 11)}, {rnd.Next(1, 11)}, {rnd.Next(1, 11)}, {rnd.Next(1, 11)}, {rnd.Next(1, 11)})";
                command = new SqlCommand(query, _sqlConnection);
                command.ExecuteNonQuery();

                stopwatch.Stop();

                _sqlConnection.Close();

                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return 0;
        }

        public long SelectAllRows()
        {
            try
            {
                _sqlConnection.Open();

                Stopwatch stopwatch = new Stopwatch();
                SqlCommand command;
                stopwatch.Start();

                string query = "SELECT * FROM Tests";
                command = new SqlCommand(query, _sqlConnection);
                command.ExecuteNonQuery();

                stopwatch.Stop();

                _sqlConnection.Close();

                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return 0;
        }

        public long Select1Row()
        {
            try
            {
                _sqlConnection.Open();

                Stopwatch stopwatch = new Stopwatch();
                SqlCommand command;
                stopwatch.Start();

                string query = "SELECT Top 1 * FROM Tests";
                command = new SqlCommand(query, _sqlConnection);
                command.ExecuteNonQuery();

                stopwatch.Stop();

                _sqlConnection.Close();

                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return 0;
        }

        public long SelectRowByValue()
        {
            try
            {
                _sqlConnection.Open();

                Stopwatch stopwatch = new Stopwatch();
                SqlCommand command;
                stopwatch.Start();

                string query = "SELECT * FROM Tests WHERE Value1 = 5";
                command = new SqlCommand(query, _sqlConnection);
                command.ExecuteNonQuery();

                stopwatch.Stop();

                _sqlConnection.Close();

                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return 0;
        }

    }
}
