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
    public partial class doctor_menu : Window
    {

        public doctor_menu(string id)
        {
            InitializeComponent();
            FillDataGrid1(id);
            FillDataGrid2();
        }

        
        private void PatientsInfo_Click1(object sender, RoutedEventArgs e)
        {
            Staff_addition.Visibility = Visibility.Hidden;
            My_schedule.Visibility = Visibility.Hidden;
            Patients_info.Visibility = Visibility.Visible;
        }

        private void PatientsInfo_Click2(object sender, RoutedEventArgs e)
        {
            Staff_addition.Visibility = Visibility.Hidden;
            Patients_info.Visibility = Visibility.Hidden;
            My_schedule.Visibility = Visibility.Visible;
        }

        private void PatientsInfo_Click3(object sender, RoutedEventArgs e)
        {
            Patients_info.Visibility = Visibility.Hidden;
            My_schedule.Visibility = Visibility.Hidden;
            Staff_addition.Visibility = Visibility.Visible;
        }

        private void insert_ward(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            sqlCon.Open();
            string sql1 = "";
            sql1 = "Select max(doctor_id) from doctor";
            SqlCommand sqlCmd1 = new SqlCommand(sql1, sqlCon);
            int id = Convert.ToInt32(sqlCmd1.ExecuteScalar()) + 1;

            using (SqlConnection openCon = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = hospital_db; Integrated Security = True; "))
            {
                string saveStaff = "Insert into doctor (doctor_id, position, name, surname, db, phone,  password, salary) values(@id, @position, @name, @surname, @db, @phone,  @password, @salary)";

                using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                {
                    querySaveStaff.Connection = openCon;
                    querySaveStaff.Parameters.AddWithValue("@id", id);
                    querySaveStaff.Parameters.AddWithValue("@position", combobox1.Text);
                    querySaveStaff.Parameters.AddWithValue("@name", name.Text);
                    querySaveStaff.Parameters.AddWithValue("@surname", surname.Text);
                    querySaveStaff.Parameters.AddWithValue("@db", Convert.ToDateTime(datepicker1.SelectedDate));
                    querySaveStaff.Parameters.AddWithValue("@phone", phone.Text);
                    querySaveStaff.Parameters.AddWithValue("@password", password.Password);
                    querySaveStaff.Parameters.AddWithValue("@salary", Convert.ToInt32(salary.Text));

                    openCon.Open();

                    querySaveStaff.ExecuteNonQuery();
                }
            }
            sqlCon.Close();
            MessageBox.Show($"{name.Text} {surname.Text} has been successfully added to the system!");

        }



        private void FillDataGrid1(string id)
        {
            //SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            
                try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                
                String CmdString1 = "Select name, surname, date from patient join visit on patient.patient_id=visit.patient_id where doctor_id=@id and duration is NULL";
                SqlCommand sqlCmd1 = new SqlCommand(CmdString1, sqlCon);
                sqlCmd1.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd1);
                DataTable dt = new DataTable("My schedule");
                sda.Fill(dt);
                My_schedule.ItemsSource = dt.DefaultView;
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

        private void FillDataGrid2()
        {
            //SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String CmdString2 = "Select name, surname, gender, db, phone from patient";
                SqlCommand sqlCmd2 = new SqlCommand(CmdString2, sqlCon);
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd2);
                DataTable dt = new DataTable("Patients info");
                sda.Fill(dt);
                Patients_info.ItemsSource = dt.DefaultView;
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
