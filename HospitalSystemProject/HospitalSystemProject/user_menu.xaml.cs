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
    /// Логика взаимодействия для user_menu.xaml
    /// </summary>
    public partial class user_menu : Window
    {
        public user_menu(string id)
        {
            InitializeComponent();
            FillDataGrid1(id);
            FillDataGrid2();
            FillDataGrid3(id);
            binding();
        }
        private void pI(object sender, RoutedEventArgs e)
        {
            v_info.Visibility = Visibility.Hidden;
            CB.Visibility = Visibility.Hidden;
            CB11.Visibility = Visibility.Hidden;
            CB.Visibility = Visibility.Hidden;
            d_info.Visibility = Visibility.Hidden;
            patient_info.Visibility = Visibility.Visible;
        }

        private void vI(object sender, RoutedEventArgs e)
        {
            v_info.Visibility = Visibility.Visible;
            CB.Visibility = Visibility.Hidden;
            CB11.Visibility = Visibility.Hidden;
            CB.Visibility = Visibility.Hidden;
            d_info.Visibility = Visibility.Hidden;
            patient_info.Visibility = Visibility.Hidden;
        }

        private void dI(object sender, RoutedEventArgs e)
        {
            v_info.Visibility = Visibility.Hidden;
            CB.Visibility = Visibility.Hidden;
            CB11.Visibility = Visibility.Hidden;
            CB.Visibility = Visibility.Hidden;
            d_info.Visibility = Visibility.Visible;
            patient_info.Visibility = Visibility.Hidden;
        }
        private void l_out(object sender, RoutedEventArgs e)
        {
            
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void search(object sender, RoutedEventArgs e)
        {
            v_info.Visibility = Visibility.Hidden;
            lbl.Visibility = Visibility.Visible;
            patient_info.Visibility = Visibility.Hidden;
            d_info.Visibility = Visibility.Hidden;
            CB.Visibility = Visibility.Visible;
            CB11.Visibility = Visibility.Visible;
        }

        private void bc1(object sender, RoutedEventArgs e)
        {
            dp.Visibility = Visibility.Visible;
            dp1.Visibility = Visibility.Visible;
        }
        private void bc2(object sender, RoutedEventArgs e)
        {
            SB.Visibility = Visibility.Visible;
        }

        private void bc3(object sender, RoutedEventArgs e)
        {
            string sn = CB.Text;
            DateTime dateTime = Convert.ToDateTime(dp.Text);
            SqlConnection sqlCon = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = hospital_db; Integrated Security = True; ");
            sqlCon.Open();
            string sql1 = "Select doctor_id from doctor where surname=@surname";
            SqlCommand sqlCmd1 = new SqlCommand(sql1, sqlCon);
            sqlCmd1.Parameters.AddWithValue("@surname", sn);
            int id = Convert.ToInt32(sqlCmd1.ExecuteScalar());
            using (SqlConnection openCon = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = hospital_db; Integrated Security = True; "))
            {
                string saveStaff = "Insert into visit (doctor_id, date) values(@doctor_id, @date)";

                using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                {
                    querySaveStaff.Connection = openCon;
                    querySaveStaff.Parameters.AddWithValue("@doctor_id", id);
                    querySaveStaff.Parameters.AddWithValue("@date", dateTime);
                    openCon.Open();

                    querySaveStaff.ExecuteNonQuery();
                }
            }
            MessageBox.Show($"You are visiting doctor at {dateTime}");
            lbl.Visibility = Visibility.Hidden;
            CB.Visibility = Visibility.Hidden;
            CB11.Visibility = Visibility.Hidden;
            dp.Visibility = Visibility.Hidden;
            dp1.Visibility = Visibility.Hidden;
            SB.Visibility = Visibility.Hidden;
        }




        private void FillDataGrid1(string id)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");

            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                String CmdString1 = "Select name from patient where patient_id=@id";
                String CmdString2 = "Select surname from patient where patient_id=@id";
                String CmdString3 = "Select db from patient where patient_id=@id";
                String CmdString4 = "Select phone from patient where patient_id=@id";
                String CmdString5 = "Select count(1) from visit where patient_id=@id";
                SqlCommand sqlCmd1 = new SqlCommand(CmdString1, sqlCon);
                SqlCommand sqlCmd2 = new SqlCommand(CmdString2, sqlCon);
                SqlCommand sqlCmd3 = new SqlCommand(CmdString3, sqlCon);
                SqlCommand sqlCmd4 = new SqlCommand(CmdString4, sqlCon);
                SqlCommand sqlCmd5 = new SqlCommand(CmdString5, sqlCon);
                sqlCmd1.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                sqlCmd2.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                sqlCmd3.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                sqlCmd4.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                sqlCmd5.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                string n = Convert.ToString(sqlCmd1.ExecuteScalar());
                string s = Convert.ToString(sqlCmd2.ExecuteScalar());
                string d = Convert.ToString(sqlCmd3.ExecuteScalar());
                string p = Convert.ToString(sqlCmd4.ExecuteScalar());
                string count1 = Convert.ToString(sqlCmd5.ExecuteScalar());
                name.Text = n;
                surname.Text = s;
                dob.Text = d.Substring(0, 10);
                phone.Text = p;
                nov.Text = count1;
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
        public void binding()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;"))
            {
                connection.Open();
                string query = "SELECT surname FROM doctor";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CB.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }
        private void CB_TextChanged(object sender, EventArgs e)
        {
            int itemsIndex = 0;
            foreach (string item in CB.Items)
            {
                if (item.Contains(CB.Text))
                {
                    CB.SelectedIndex = itemsIndex;
                    break;
                }
                itemsIndex++;
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
                String CmdString2 = "Select name, surname, position, db, phone from doctor";
                SqlCommand sqlCmd2 = new SqlCommand(CmdString2, sqlCon);
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd2);
                DataTable dt = new DataTable("All wards");
                sda.Fill(dt);
                d_info.ItemsSource = dt.DefaultView;
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

        private void FillDataGrid3(string id)
        {
            //SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=hospital_db; Integrated Security=True;");
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String CmdString5 = "Select name, surname, date from visit join doctor on visit.doctor_id=doctor.doctor_id where patient_id=@id and duration is null";
                SqlCommand sqlCmd5 = new SqlCommand(CmdString5, sqlCon);
                SqlDataAdapter sda = new SqlDataAdapter(sqlCmd5);
                sqlCmd5.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                DataTable x = new DataTable("Your visits");
                sda.Fill(x);
                v_info.ItemsSource = x.DefaultView;
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
