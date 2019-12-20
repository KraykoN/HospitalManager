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
//        Before starting the program for the first time, be sure to change the path to the image in both classes user_menu and doctor_menu.Also, for starting ownload and restore the database backup for the project.This is uploaded to the github archive.zip.Be sure to follow her hospital name "hospital_db", run only on localhost in Sql Server Management Studio.
//Please observe the code entry settings in the program.
        public MainWindow()
        {
            InitializeComponent();
            

        }
        private void btnSubmit_Click1(object sender, RoutedEventArgs e)
        {
            Registration dashboard = new Registration();
            dashboard.Show();
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query1 = "SELECT COUNT(1) FROM doctor WHERE phone=@phone AND password=@password";
                String query2 = "SELECT COUNT(1) FROM patient WHERE phone=@phone AND password=@password";
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon);
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd1.CommandType = CommandType.Text;
                sqlCmd2.CommandType = CommandType.Text;
                sqlCmd1.Parameters.AddWithValue("@phone", txtUsername.Text);
                sqlCmd2.Parameters.AddWithValue("@phone", txtUsername.Text);
                sqlCmd1.Parameters.AddWithValue("@password", txtPassword.Password);
                sqlCmd2.Parameters.AddWithValue("@password", txtPassword.Password);
                int count1 = Convert.ToInt32(sqlCmd1.ExecuteScalar());
                int count2 = Convert.ToInt32(sqlCmd2.ExecuteScalar());
                if (count1 == 1)
                {
                    
                    String query3 = "SELECT doctor_id FROM doctor WHERE phone=@phone";
                    SqlCommand sqlCmd3 = new SqlCommand(query3, sqlCon);
                    sqlCmd3.Parameters.AddWithValue("@phone", txtUsername.Text);
                    string id = Convert.ToString(sqlCmd3.ExecuteScalar());
                    doctor_menu dashboard = new doctor_menu(id);
                    
                    dashboard.Show();
                    this.Close();
                }
                else if(count2 == 1)
                {

                    String query4 = "SELECT patient_id FROM patient WHERE phone=@phone";
                    SqlCommand sqlCmd3 = new SqlCommand(query4, sqlCon);
                    sqlCmd3.Parameters.AddWithValue("@phone", txtUsername.Text);
                    string id = Convert.ToString(sqlCmd3.ExecuteScalar());
                    user_menu dashboard = new user_menu(id);
                    dashboard.Show();
                    this.Close();
                }
                else if(count1!=1&&count2!=1)
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
    }
}
