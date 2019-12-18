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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string gender = "";

            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            try
            {
                sqlCon.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                
                string sql2 = "";
                sql2 = "SELECT COUNT(1) FROM patient WHERE phone=@phone";
                SqlCommand sqlCmd2 = new SqlCommand(sql2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@phone", phone.Text);
                int c1 = Convert.ToInt32(sqlCmd2.ExecuteScalar());

                string sql3 = "";
                sql3 = "SELECT COUNT(1) FROM doctor WHERE phone=@phone";
                SqlCommand sqlCmd3 = new SqlCommand(sql2, sqlCon);
                sqlCmd3.Parameters.AddWithValue("@phone", phone.Text);
                int c2 = Convert.ToInt32(sqlCmd2.ExecuteScalar());

                if (RB1.IsChecked==true)
                {
                    gender = "M";
                }
                if(RB2.IsChecked==true)
                {
                    gender = "F";
                }
                if ((name.Text == "") || (surname.Text == "") || (password.Password == "") || (dob.Text == ""))
                {
                    MessageBox.Show("Not all fields are filled!");
                }
                
                else if (c1==1 || c2==1)
                {
                    MessageBox.Show("User with this phone number already exists!");
                }
                else if(c1!=1&&c2!=1)
                {
                    string sql1 = "";
                    sql1 = "Select max(patient_id) from patient";
                    SqlCommand sqlCmd1 = new SqlCommand(sql1, sqlCon);
                    int id = Convert.ToInt32(sqlCmd1.ExecuteScalar()) + 1;

                    using (SqlConnection openCon = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = hospital_db; Integrated Security = True; "))
                    {
                        string saveStaff = "Insert into patient (patient_id, name, surname, db, phone,  password, gender) values(@id, @name, @surname, @db, @phone, @password, @gender)";

                        using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                        {
                            querySaveStaff.Connection = openCon;
                            querySaveStaff.Parameters.AddWithValue("@id", id);
                            querySaveStaff.Parameters.AddWithValue("@name", name.Text);
                            querySaveStaff.Parameters.AddWithValue("@surname", surname.Text);
                            querySaveStaff.Parameters.AddWithValue("@db", dob.Text);
                            querySaveStaff.Parameters.AddWithValue("@phone", phone.Text);
                            querySaveStaff.Parameters.AddWithValue("@password", password.Password);
                            querySaveStaff.Parameters.AddWithValue("@gender", gender);

                            openCon.Open();

                            querySaveStaff.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Registered succesfully!");
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                    
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
