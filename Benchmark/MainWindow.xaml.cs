using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Benchmark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppTableCreatingTool tool = new AppTableCreatingTool(@"Data Source=(localdb)\ProjectsV13; Initial Catalog=BnchMrk; Integrated Security=true;");
        Queries queries = new Queries(@"Data Source=(localdb)\ProjectsV13; Initial Catalog=BnchMrk; Integrated Security=true;");
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13; Initial Catalog=BnchMrk; Integrated Security=true;");

        public MainWindow()
        {
            InitializeComponent();

            tool.CreateResultsTable();
            tool.CreateMainTable();
        }

        private void insert1000Values_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                queries.Insert1000Rows();
                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void insert1Values_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                queries.Insert1Row();
                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void selectAllButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                queries.SelectAllRows();
                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void select1rowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                queries.Select1Row();
                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void selectByValueButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                queries.Select1Row();
                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void UpdateDataGrid()
        {
            sqlConnection.Open();

            string query = "SELECT * FROM Results";
            SqlCommand command = new SqlCommand(query, sqlConnection);

            command.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("BnchMrk");
            dataAdapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            dataAdapter.Update(dataTable);

            sqlConnection.Close();
        }

      
    }
}
