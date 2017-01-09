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
    public partial class Add_new_Follow_Up : Form
    {
        private OleDbConnection conn;
        private String connectionStr;

        private List<int> pastHistory;
        private List<int> selectedPastHistory;

        private List<int> familyHistory;
        private List<int> selectedFamilyHistory;

        private int patientID = 0;

        public Add_new_Follow_Up()
        {
            InitializeComponent();

            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);

            selectedFamilyHistory = new List<int>();
            selectedPastHistory = new List<int>();
        }

        public Add_new_Follow_Up(int patientID)
            : this()
        {
            this.patientID = patientID;

            loadPastHistory();
            loadFamilyHistory();
        }

        private void number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || char.IsControl(e.KeyChar))
                //Do not reject the input
                e.Handled = false;
            else
                //Reject the input
                e.Handled = true;
        }
        private void btn_addFollowUpAction_Click(object sender, EventArgs e)
        {
            int followUpID = addFollowUp();
            addAllPastHistory(followUpID);
            addAllFamilyHistoy(followUpID);
            MessageBox.Show("Follow Up added SUCCESSFULLY");
            this.Close();
        }

        private void addAllFamilyHistoy(int followUpID)
        {
            foreach (int selected in selectedFamilyHistory)
                addFamilyHistory(followUpID, selected);
        }

        private void addFamilyHistory(int followUpID, int selected)
        {
            try
            {
                conn.Open();

                String sql = "INSERT INTO Family_History (follow_up_id, hValue) VALUES (@fID, @hValue)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@fID", followUpID);
                command.Parameters.AddWithValue("@hValue", selected);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void addAllPastHistory(int followUpID)
        {
            foreach (int selected in selectedPastHistory)
                addPastHistory(followUpID, selected);
        }

        private void addPastHistory(int followUpID, int selected)
        {
            try
            {
                conn.Open();

                String sql = "INSERT INTO Past_History (follow_up_id, hValue) VALUES (@fID, @hValue)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@fID", followUpID);
                command.Parameters.AddWithValue("@hValue", selected);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private int addFollowUp()
        {
            try
            {
                conn.Open();

                String sql = "INSERT INTO Follow_Up "
                    + "(patient_id, parity_a, parity_b, living, male, female, lmp, rh, menarchal, cycle_d, cycle_c, notes, start_date) "
                    + "VALUES (@pID, @parA, @parB, @living, @male, @female, @lmp, @rh, @men, @cycleD, @cycleC, @notes, @sdate)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@pID", patientID);
                command.Parameters.AddWithValue("@parA", numberValue(txt_parityA.Text));
                command.Parameters.AddWithValue("@parB", numberValue(txt_parityB.Text));
                command.Parameters.AddWithValue("@living", numberValue(txt_living.Text));
                command.Parameters.AddWithValue("@male", numberValue(txt_male.Text));
                command.Parameters.AddWithValue("@female", numberValue(txt_female.Text));
                command.Parameters.AddWithValue("@lmp", date_lmp.Value.Date);
                command.Parameters.AddWithValue("@rh", rhValue());
                command.Parameters.AddWithValue("@men", numberValue(txt_menarchal.Text));
                command.Parameters.AddWithValue("@cycleD", numberValue(txt_cycleD.Text));
                command.Parameters.AddWithValue("@cycleC", numberValue(txt_cycleC.Text));
                command.Parameters.AddWithValue("@notes", rtxt_notes.Text);
                command.Parameters.AddWithValue("@sdate", date_startDate.Value.Date.ToString());

                command.ExecuteNonQuery();

                command = new OleDbCommand("SELECT @@IDENTITY", conn);

                return (int)command.ExecuteScalar(); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public int numberValue(String s)
        {
            return Convert.ToInt32(ZeroIfEmpty(s));
        }

        public String ZeroIfEmpty(String s)
        {
            return String.IsNullOrEmpty(s) ? "0" : s;
        }

        public String rhValue()
        {
            if (string.IsNullOrEmpty(combo_rh.Text.ToString()))
            {
                MessageBox.Show("RH is not selected");
                return "";
            }

            return combo_rh.SelectedItem.ToString();
        }

        private void btn_addFHistory_Click(object sender, EventArgs e)
        {
            if (combo_familyHistory.SelectedIndex < 0)
            {
                MessageBox.Show("No value selected");
                return;
            }

            String fHistory = combo_familyHistory.SelectedItem.ToString();
            listBox_FamilyHistory.Items.Add(fHistory);
            selectedFamilyHistory.Add(familyHistory[combo_familyHistory.SelectedIndex]);
        }

        private void btn_addPHistory_Click(object sender, EventArgs e)
        {
            if (combo_pastHistory.SelectedIndex < 0)
            {
                MessageBox.Show("No value selected");
                return;
            }

            String pHistory = combo_pastHistory.SelectedItem.ToString();
            listBox_pastHistory.Items.Add(pHistory);
            selectedPastHistory.Add(pastHistory[combo_pastHistory.SelectedIndex]);
        }

        private void btn_removePHistory_Click(object sender, EventArgs e)
        {
            if (listBox_pastHistory.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("No item Selected !!!");
                return;
            }

            int intselectedindex = listBox_pastHistory.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                listBox_pastHistory.Items.RemoveAt(intselectedindex);
                selectedPastHistory.RemoveAt(intselectedindex);
            }
        }

        private void btn_removeFHistory_Click(object sender, EventArgs e)
        {
            if (listBox_FamilyHistory.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("No item Selected !!!");
                return;
            }

            int intselectedindex = listBox_FamilyHistory.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                listBox_FamilyHistory.Items.RemoveAt(intselectedindex);
                selectedFamilyHistory.RemoveAt(intselectedindex);
            }
        }

        private void combo_pastHistory_DropDown(object sender, EventArgs e)
        {
//            loadPastHistory();
       }

        private void combo_familyHistory_DropDown(object sender, EventArgs e)
        {
//            loadFamilyHistory();
        }

        private void loadPastHistory()
        {
            try
            {
                conn.Open();

                String sql = "SELECT * FROM Values_Past_History";

                OleDbCommand command = new OleDbCommand(sql, conn);
                OleDbDataReader dr = command.ExecuteReader();

                pastHistory = new List<int>();
                combo_pastHistory.Items.Clear();
                while (dr.Read())
                {
                    pastHistory.Add(dr.GetInt32(dr.GetOrdinal("ID")));
                    String value = dr.GetString(dr.GetOrdinal("hName"));
                    combo_pastHistory.Items.Add(value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void loadFamilyHistory()
        {
            try
            {
                conn.Open();

                String sql = "SELECT * FROM Values_Family_History";

                OleDbCommand command = new OleDbCommand(sql, conn);
                OleDbDataReader dr = command.ExecuteReader();

                familyHistory = new List<int>();
                combo_familyHistory.Items.Clear();
                while (dr.Read())
                {
                    familyHistory.Add(dr.GetInt32(dr.GetOrdinal("ID")));
                    String value = dr.GetString(dr.GetOrdinal("hName"));
                    combo_familyHistory.Items.Add(value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_pastRefresh_Click(object sender, EventArgs e)
        {
            loadPastHistory();
        }

        private void btn_familyRefresh_Click(object sender, EventArgs e)
        {
            loadFamilyHistory();
        }

        private void date_lmp_ValueChanged(object sender, EventArgs e)
        {
            DateTime edd = date_lmp.Value;
            edd = edd.AddMonths(9).AddDays(7);
            txt_edd.Text = edd.ToString("dd/MM/yyyy");
        }

    }
}
