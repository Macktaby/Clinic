using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.Froms
{
    public partial class Patient : Form
    {
        private OleDbConnection conn;
        private String connectionStr;
        private int id;
        private List<int> followUps;

        public Patient()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);
        }

        public Patient(int id)
            : this()
        {
            this.id = id;
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            loadPatientInfo();
            //            getFollowUps();
        }

        private void getFollowUps()
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Follow_Up WHERE Follow_Up.patient_id = @id ORDER BY start_date DESC";
                OleDbCommand command = new OleDbCommand(sql, conn);
                command.Parameters.AddWithValue("@id", id);
                OleDbDataReader dr = command.ExecuteReader();

                followUps = new List<int>();
                combo_followUps.Items.Clear();
                while (dr.Read())
                {
                    followUps.Add(dr.GetInt32(dr.GetOrdinal("follow_up_id")));
                    combo_followUps.Items.Add(dr.GetDateTime(dr.GetOrdinal("start_date")));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured !!!" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void loadPatientInfo()
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Patient WHERE Patient.patient_id = @id";
                // AND Patient.patient_id = Follow_Up.patient_id
                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@id", id);

                OleDbDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    txt_patientName.Text = dr["patient_name"].ToString();
                    txt_husbandName.Text = dr["husband_name"].ToString();
                    txt_phone.Text = dr["phone"].ToString();

                    int colIndex = 0;
                    colIndex = dr.GetOrdinal("patient_bdate");
                    num_patientAge.Text = calcAge(dr.GetDateTime(colIndex));
                    colIndex = dr.GetOrdinal("husband_bdate");
                    num_husbandAge.Text = calcAge(dr.GetDateTime(colIndex));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured !!!" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private string calcAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;

            return age.ToString();
        }

        private void combo_followUps_DropDown(object sender, EventArgs e)
        {
            getFollowUps();
        }

        private void combo_followUps_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Reject the input
            e.Handled = true;
        }

        private void combo_followUps_SelectedIndexChanged(object sender, EventArgs e)
        {
            int followUpID = followUps[combo_followUps.SelectedIndex];

            getFollowUp(followUpID);
        }

        private void getFollowUp(int followUpID)
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Follow_Up WHERE Follow_Up.follow_up_id = @id";
                // Past_History, Family_History 
                // AND Follow_Up.follow_up_id = Follow_Up.follow_up_id AND Follow_Up.follow_up_id = Follow_Up.follow_up_id
                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@id", followUpID);

                OleDbDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    txt_parityA.Text = dr.GetInt32(dr.GetOrdinal("parity_a")).ToString();
                    txt_parityB.Text = dr.GetInt32(dr.GetOrdinal("parity_b")).ToString();

                    txt_lmp.Text = Convert.ToString(dr.GetDateTime(dr.GetOrdinal("lmp")));
                    DateTime edd = dr.GetDateTime(dr.GetOrdinal("lmp"));
                    edd.AddMonths(9).AddDays(7);
                    txt_edd.Text = edd.ToString();

                    txt_living.Text = dr.GetInt32(dr.GetOrdinal("living")).ToString();
                    txt_male.Text = dr.GetInt32(dr.GetOrdinal("male")).ToString();
                    txt_female.Text = dr.GetInt32(dr.GetOrdinal("female")).ToString();
                    txt_rh.Text = dr.GetString(dr.GetOrdinal("rh"));
                    txt_menarchal.Text = dr.GetInt32(dr.GetOrdinal("menarchal")) + "Years Old";
                    txt_cycleD.Text = dr.GetInt32(dr.GetOrdinal("cycle_d")).ToString();
                    txt_cycleC.Text = dr.GetInt32(dr.GetOrdinal("cycle_c")).ToString();

                    // GET PAST AND FAMILY HISTORY
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured !!!" + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }



    }
}
