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
    public partial class AddNewVisit : Form
    {
        private OleDbConnection conn;
        private String connectionStr;

        private int followUpID;
        private DateTime lmp;
        private int days;

        private List<int> medicines;
        private List<int> selectedMedications;

        public AddNewVisit()
        {
            InitializeComponent();

            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);
            
            medicines = new List<int>();
            selectedMedications = new List<int>();
        }
        public AddNewVisit(int followUpID, DateTime lmp)
            : this()
        {
            this.followUpID = followUpID;
            this.lmp = lmp;

            DateTime now = DateTime.Today;
            txt_curentDate.Text = now.ToString("dd/MM/yyyy");
            days = (now - lmp).Days;

            txt_gasAge.Text = (days / 7) + " Week(s) and " + (days % 7) + " Day(s)";
        }

        private void loadMedicines()
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Medicine";
                OleDbCommand command = new OleDbCommand(sql, conn);
                OleDbDataReader dr = command.ExecuteReader();

                medicines = new List<int>();
                combo_medication.Items.Clear();
                while (dr.Read())
                {
                    medicines.Add(dr.GetInt32(dr.GetOrdinal("medicine_id")));
                    String med = dr[dr.GetOrdinal("medicine_name")] + " " + dr[dr.GetOrdinal("concentration")];
                    combo_medication.Items.Add(med);
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


        public int numberValue(String s)
        {
            return Convert.ToInt32(ZeroIfEmpty(s));
        }

        public String ZeroIfEmpty(String s)
        {
            return String.IsNullOrEmpty(s) ? "0" : s;
        }

        public String stringValue(String value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            return value;
        }

        private void btn_addVisitAction_Click(object sender, EventArgs e)
        {
            int visitID = addVisit();
        }

        private int addVisit()
        {
            try
            {
                conn.Open();

                String sql = "INSERT INTO Visit "
                    + "(weight, bl_pr_num, bl_pr_dom, tmp, ultra_sound, notes, follow_up_id) "
                    + "VALUES (@weight, @bl_num, @bl_dom, @tmp, @ultra, @notes, @fID)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@weight", numberValue(txt_weight.Text));
                command.Parameters.AddWithValue("@bl_num", numberValue(txt_bl_pr_num.Text));
                command.Parameters.AddWithValue("@bl_dom", numberValue(txt_bl_pr_dom.Text));
                command.Parameters.AddWithValue("@tmp", numberValue(txt_tmp.Text));
                command.Parameters.AddWithValue("@ultra", stringValue(txt_ultraSound.Text));
                command.Parameters.AddWithValue("@notes", stringValue(txt_notes.Text));
                command.Parameters.AddWithValue("@fID", followUpID);

                command.ExecuteNonQuery();

                command = new OleDbCommand("SELECT @@IDENTITY", conn);
                int id = (int)command.ExecuteScalar();

                addVisitMedications(id);
                MessageBox.Show("The visit is added SUCCESSFULLY", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return id;
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

        private void addVisitMedications(int visitID)
        {
            for (int i = 0; i < listBox_visitMedications.Items.Count; i++)
                addVisitMedication(visitID, selectedMedications[i]);
        }

        private void addVisitMedication(int visitID, int medicineID)
        {
            try
            {
                String sql = "INSERT INTO Visit_Medication (visit_id, medicine_id) VALUES (@vID, @mID)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@vID", visitID);
                command.Parameters.AddWithValue("@mID", medicineID);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
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

        private void btn_addMedication_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(combo_medication.Text))
            {
                MessageBox.Show("No medicine selected");
                return;
            }

            String med = combo_medication.Text.ToString();
            listBox_visitMedications.Items.Add(med);
            selectedMedications.Add(medicines[combo_medication.SelectedIndex]);
        }

        private void btn_removeMedication_Click(object sender, EventArgs e)
        {
            if (listBox_visitMedications.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("No medicine Selected !!!");
                return;
            }

            int intselectedindex = listBox_visitMedications.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                listBox_visitMedications.Items.RemoveAt(intselectedindex);
                selectedMedications.RemoveAt(intselectedindex);
            }
        }

        private void combo_medication_DropDown(object sender, EventArgs e)
        {
            loadMedicines();
        }

    }
}
