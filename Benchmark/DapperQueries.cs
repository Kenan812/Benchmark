using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace Benchmark
{
    class DapperQueries
    {
        string _connectionString;

        public DapperQueries(string connectionString)
        {
            _connectionString = connectionString;
        }


        public long Insert1000Rows()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Random rnd = new Random();
                Stopwatch stopwatch = new Stopwatch();


                string query = "INSERT INTO Tests(Value1, Value2, Value3, Value4, Value5) VALUES(@Value1, @Value2, @Value3, @Value4, @Value5)";
                stopwatch.Start();
                for (int i = 0; i < 1000; i++)
                {
                    db.Execute(query, new { Value1 = rnd.Next(1, 11), Value2 = rnd.Next(1, 11), Value3 = rnd.Next(1, 11), Value4 = rnd.Next(1, 11), Value5 = rnd.Next(1, 11) });
                }

                stopwatch.Stop();

                return stopwatch.ElapsedMilliseconds;
            }
        }

        public long Insert1Rows()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Random rnd = new Random();
                Stopwatch stopwatch = new Stopwatch();


                string query = "INSERT INTO Tests(Value1, Value2, Value3, Value4, Value5) VALUES(@Value1, @Value2, @Value3, @Value4, @Value5)";
                stopwatch.Start();

                db.Execute(query, new { Value1 = rnd.Next(1, 11), Value2 = rnd.Next(1, 11), Value3 = rnd.Next(1, 11), Value4 = rnd.Next(1, 11), Value5 = rnd.Next(1, 11) });

                stopwatch.Stop();

                return stopwatch.ElapsedMilliseconds;
            }
        }

        public long SelectAllRows()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Stopwatch stopwatch = new Stopwatch();


                string query = "SELECT * FROM Tests";
                stopwatch.Start();

                db.Execute(query);

                stopwatch.Stop();

                return stopwatch.ElapsedMilliseconds;
            }
        }

        public long Select1Row()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Stopwatch stopwatch = new Stopwatch();

                string query = "SELECT Top 1 * FROM Tests";
                stopwatch.Start();

                db.Execute(query);

                stopwatch.Stop();

                return stopwatch.ElapsedMilliseconds;
            }
        }

        public long SelectRowByValue()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Stopwatch stopwatch = new Stopwatch();

                string query = "SELECT * FROM Tests WHERE Value1 = 5";
                stopwatch.Start();

                db.Execute(query);

                stopwatch.Stop();

                return stopwatch.ElapsedMilliseconds;
            }
        }
    }
}
