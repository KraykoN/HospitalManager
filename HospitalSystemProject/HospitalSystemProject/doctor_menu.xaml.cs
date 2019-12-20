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
    public partial class doctor_menu : Window//, INotifyPropertyChanged
    {
        //private double _value;

        public doctor_menu(string id)
        {
            InitializeComponent();
            FillDataGrid1(id);
            FillDataGrid2();
            Window_Loaded();
            LoadVisitsToday(id);
        }


        private void CheckOut_Click(object sender, RoutedEventArgs e)
        {
            if ((date1.Text == "") || (surname1.Text == "") || (duration1.Text == "") || (additional_payment1.Text == "") || (disease1.Text == ""))
            {
                MessageBox.Show("Not all fields are filled!");
            }
            else
            {

                SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
                sqlCon.Open();
                string sql1 = "Select patient_id from patient where surname=@surname";
                SqlCommand sqlCmd1 = new SqlCommand(sql1, sqlCon);
                sqlCmd1.Parameters.AddWithValue("@surname", Convert.ToString(surname1.Text));
                int id = Convert.ToInt32(sqlCmd1.ExecuteScalar());
                using (SqlConnection openCon = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = hospital_db; Integrated Security = True; "))
                {
                    string saveStaff = "update visit set duration = @duration, additional_payment = @pay, disease = @disease where visit.date = @dateee1 and visit.patient_id = @id";

                    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                    {
                        querySaveStaff.Connection = openCon;
                        querySaveStaff.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                        querySaveStaff.Parameters.AddWithValue("@duration", Convert.ToInt32(duration1.Text));
                        querySaveStaff.Parameters.AddWithValue("@pay", Convert.ToInt32(additional_payment1.Text));
                        querySaveStaff.Parameters.AddWithValue("@disease", Convert.ToString(disease1.Text));
                        querySaveStaff.Parameters.AddWithValue("@dateee1", Convert.ToDateTime(date1.Text));


                        openCon.Open();

                        querySaveStaff.ExecuteNonQuery();

                    }
                }
                MessageBox.Show("Registered succesfully!");
            }
        }

        public void Calculate_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDt = new DateTime();
            DateTime finishDt = new DateTime();

            if (DateTime.TryParse(StartDate.Text, out _) && DateTime.TryParse(FinishDate.Text, out _))
            {
                startDt = Convert.ToDateTime(StartDate.Text);
                finishDt = Convert.ToDateTime(FinishDate.Text);
                SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");

                try
                {
                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();

                    String CmdString1 = "SET DATEFORMAT DMY select COUNT(doctor_id) from visit where (Date BETWEEN @DATE1 AND @DATE2);";
                    SqlCommand sqlCmd1 = new SqlCommand(CmdString1, sqlCon);
                    sqlCmd1.Parameters.AddWithValue("@DATE1", Convert.ToString(startDt));
                    sqlCmd1.Parameters.AddWithValue("@DATE2", Convert.ToString(finishDt));

                    ProfitBox.Text = Convert.ToString(sqlCmd1.ExecuteScalar());
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
            else
            {
                MessageBox.Show("This format of date does not supported. ");
            }
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void MyStatistics_Click(object sender, RoutedEventArgs e)
        {
            Stata.Visibility = Visibility.Visible;
            Staff_addition.Visibility = Visibility.Hidden;
            Patients_info.Visibility = Visibility.Hidden;
            My_schedule.Visibility = Visibility.Hidden;
            CheckOut.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded()
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, t) => { TimeLabel.Content = DateTime.Now.ToString(); };
            timer.Start();
        }
        //private void ExportExcel_Click(object sender, RoutedEventArgs e)
        //{
        // <Button Name = "ImportExcel" Content="Export to Excel" Margin="384,378,162,78" Height="54" Width="214" Click="ExportExcel_Click" />
        //}

        private void PatientsInfo_Click1(object sender, RoutedEventArgs e)
        {
            Staff_addition.Visibility = Visibility.Hidden;
            My_schedule.Visibility = Visibility.Hidden;
            Patients_info.Visibility = Visibility.Visible;
            Stata.Visibility = Visibility.Hidden;
            CheckOut.Visibility = Visibility.Hidden;
        }

        private void PatientsInfo_Click2(object sender, RoutedEventArgs e)
        {
            Staff_addition.Visibility = Visibility.Hidden;
            Patients_info.Visibility = Visibility.Hidden;
            My_schedule.Visibility = Visibility.Visible;
            Stata.Visibility = Visibility.Hidden;
            CheckOut.Visibility = Visibility.Hidden;
        }

        private void PatientsInfo_Click3(object sender, RoutedEventArgs e)
        {
            Patients_info.Visibility = Visibility.Hidden;
            My_schedule.Visibility = Visibility.Hidden;
            Staff_addition.Visibility = Visibility.Visible;
            Stata.Visibility = Visibility.Hidden;
            CheckOut.Visibility = Visibility.Hidden;
        }

        private void CheckOut_Click2(object sender, RoutedEventArgs e)
        {
            Patients_info.Visibility = Visibility.Hidden;
            My_schedule.Visibility = Visibility.Hidden;
            Staff_addition.Visibility = Visibility.Hidden;
            Stata.Visibility = Visibility.Hidden;
            CheckOut.Visibility = Visibility.Visible;
        }

        private void insert_ward(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            sqlCon.Open();
            string sql1 = "";
            sql1 = "Select max(doctor_id) from doctor";
            SqlCommand sqlCmd1 = new SqlCommand(sql1, sqlCon);
            int id = Convert.ToInt32(sqlCmd1.ExecuteScalar()) + 1;

            using (SqlConnection openCon = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = hospital_db; Integrated Security = True; "))
            {
                string saveStaff = "Insert into doctor (doctor_id, position, name, surname, db, phone, password, salary) values(@id, @position, @name, @surname, @db, @phone, @password, @salary)";

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

        private void LoadVisitsToday(string id)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                String CmdString1 = "select COUNT(doctor_id) from visit where doctor_id=@id and duration is null and  Cast(visit.date as date) = Cast(GETDATE() as date);";
                SqlCommand sqlCmd1 = new SqlCommand(CmdString1, sqlCon);
                sqlCmd1.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                TodayVisits.Text = Convert.ToString(sqlCmd1.ExecuteScalar());
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
                My_schedule1.ItemsSource = dt.DefaultView;
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
                Patients_info1.ItemsSource = dt.DefaultView;
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