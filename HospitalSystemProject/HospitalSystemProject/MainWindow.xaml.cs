using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
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
namespace HospitalSystemProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM doctor WHERE phone=@phone AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@phone", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@password", txtPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
        //private void Loading_Password()
        //{
        //string Connect = "Server=db4free.net;Port=3306;Database=hospital_db;Uid=nikita_hse;Pwd=Asdasdasd;";
        ////MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        ////builder.Server = "db4free.net";
        ////builder.UserID = "nikita_hse";
        ////builder.Password = "Asdasdasd";
        ////builder.Database = "hospital_db";
        ////builder.Port = Convert.ToUInt16("3306");
        ////connection = new MySqlConnection(builder.ToString());
        ////connection.Open();
        //string CommandText = "INSERT INTO HW3Database (id, name, password, phone) VALUES (1, 'Иван Иванов', '123123', '89031506062')";
        ////MySqlConnection myConnection = new MySqlConnection(builder.ToString());
        //MySqlConnection myConnection = new MySqlConnection(Connect);
        //myConnection.Open();
        //MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
        //// выполняем запрос
        //myCommand.ExecuteNonQuery();
        //// закрываем подключение к БД
        //myConnection.Close();

        //}
    }
}
