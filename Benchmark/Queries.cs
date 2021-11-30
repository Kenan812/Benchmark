using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace Benchmark
{
    class Queries
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;

        
        private AdoNetQueries _adoNetQueries;
        private EFqueries _eFqueries;
        private DapperQueries _dapperQueries;


        public Queries(string connectionString)
        {
            _connectionString = connectionString;
            _sqlConnection = new SqlConnection(_connectionString);

            _adoNetQueries = new AdoNetQueries(_connectionString);
            _eFqueries = new EFqueries();
            _dapperQueries = new DapperQueries(_connectionString);
        }


        public void Insert1000Rows()
        {
            try
            {
                EmptyResultsTable();

                long timing = _adoNetQueries.Insert1000Values();
                AddResult("ADO.NET", timing);

                timing = _eFqueries.Insert1000Rows();
                AddResult("Entity Framework(all at the same time)", timing);

                timing = _dapperQueries.Insert1000Rows();
                AddResult("Dapper", timing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void Insert1Row()
        {
            try
            {
                EmptyResultsTable();
                long timing;

                timing = _adoNetQueries.Insert1Values();
                AddResult("ADO.NET", timing);

                timing = _eFqueries.Insert1Rows();
                AddResult("Entity Framework", timing);


                timing = _dapperQueries.Insert1Rows();
                AddResult("Dapper", timing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void SelectAllRows()
        {
            try
            {
                EmptyResultsTable();
                long timing;

                timing = _adoNetQueries.SelectAllRows();
                AddResult("ADO.NET", timing);

                timing = _eFqueries.SelectAllRows();
                AddResult("Entity Framework", timing);


                timing = _dapperQueries.SelectAllRows();
                AddResult("Dapper", timing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void Select1Row()
        {
            try
            {
                EmptyResultsTable();
                long timing;

                timing = _adoNetQueries.Select1Row();
                AddResult("ADO.NET", timing);

                timing = _eFqueries.Select1Row();
                AddResult("Entity Framework", timing);


                timing = _dapperQueries.Select1Row();
                AddResult("Dapper", timing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void SelectRowByValue()
        {
            try
            {
                EmptyResultsTable();
                long timing;

                timing = _adoNetQueries.SelectRowByValue();
                AddResult("ADO.NET", timing);

                timing = _eFqueries.SelectRowByValue();
                AddResult("Entity Framework", timing);


                timing = _dapperQueries.SelectRowByValue();
                AddResult("Dapper", timing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }




        private void EmptyResultsTable()
        {
            _sqlConnection.Open();
            string query = $"DELETE FROM Results";
            SqlCommand command = new SqlCommand(query, _sqlConnection);
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        private void AddResult(string resolver, long timing)
        {
            _sqlConnection.Open();
            string query = $"INSERT INTO Results(Resolver, Timing) VALUES('{resolver}', {timing})";
            SqlCommand command = new SqlCommand(query, _sqlConnection);
            command.ExecuteNonQuery();
            _sqlConnection.Close();
        }
    }
}
