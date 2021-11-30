using Benchmark.Model;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Benchmark
{
    class EFqueries
    {
        BnchMrkContext context = new BnchMrkContext();

        public long Insert1000Rows()
        {
            try
            {
                Random rnd = new Random();
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                for (int i = 0; i < 1000; i++)
                {
                    context.Tests.Add(new Test { Value1 = rnd.Next(1, 11), Value2 = rnd.Next(1, 11), Value3 = rnd.Next(1, 11), Value4 = rnd.Next(1, 11), Value5 = rnd.Next(1, 11) });
                }
                context.SaveChanges();
                stopwatch.Stop();

                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return 0;
        }

        public long Insert1Rows()
        {
            try
            {
                Random rnd = new Random();
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                context.Tests.Add(new Test { Value1 = rnd.Next(1, 11), Value2 = rnd.Next(1, 11), Value3 = rnd.Next(1, 11), Value4 = rnd.Next(1, 11), Value5 = rnd.Next(1, 11) });
                context.SaveChanges();

                stopwatch.Stop();

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
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                context.Tests.Select(x => x);

                stopwatch.Stop();

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
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                context.Tests.FirstOrDefault();

                stopwatch.Stop();

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
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                context.Tests.Where(x => x.Value1 == 5).Select(x => x);

                stopwatch.Stop();

                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return 0;
        }

        public long UpdateAllRows()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                var values = context.Tests.Select(x => x).ToList();

                foreach (Test item in values)
                {
                    item.Value1 = 1;
                }

                context.SaveChanges();

                stopwatch.Stop();

                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return 0;
        }

        public long Update1Row()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                var value = context.Tests.FirstOrDefault();

                value.Value1 = 1;

                context.SaveChanges();

                stopwatch.Stop();

                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return 0;
        }

        public long Delete1Row()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                var value = context.Tests.FirstOrDefault();
                context.Tests.Remove(value);
                context.SaveChanges();

                stopwatch.Stop();

                return stopwatch.ElapsedMilliseconds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return 0;
        }

        public long DeleteAllRows()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                context.Tests.RemoveRange(context.Tests.Select(x => x).Take(1000));
                stopwatch.Stop();

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
