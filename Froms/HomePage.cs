using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using Clinic.Froms;

namespace Clinic
{
    public partial class Form1 : Form
    {
        OleDbConnection conn;
        String connectionStr;

        public Form1()
        {
            InitializeComponent();
            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);
        }

        private void btn_addAction_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql = "INSERT INTO Patient "
                    + "(patient_name, patient_bdate, husband_name, husband_bdate, phone) "
                    + "VALUES(@name, @bdate, @hName, @hBDate, @phone)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@name", txt_patientName.Text);
                command.Parameters.AddWithValue("@bdate", date_patientBDate.Value.Date);
                command.Parameters.AddWithValue("@hName", txt_husbandName.Text);
                command.Parameters.AddWithValue("@hBDate", date_husbandBDate.Value.Date);
                command.Parameters.AddWithValue("@phone", txt_phone.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("Patient added SUCCESSFULLY", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured!!" + ex.Message);
            }
            finally
            {
                conn.Close();
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

        private void btn_searchPatient_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String sql = "SELECT * FROM Patient WHERE patient_name LIKE @name AND phone LIKE @phone";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@name", "%" + txt_patientSearchName.Text + "%");
                command.Parameters.AddWithValue("@phone", "%" + txt_patientSearchPhone.Text + "%");

                OleDbDataReader dr = command.ExecuteReader();
                Select_Patient sp = new Select_Patient(dr);
                sp.Show();
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

        private void btn_addLabLink_Click(object sender, EventArgs e)
        {
            AddLabValue form = new AddLabValue();
            form.Show();
        }

        private void btn_addPastHistValue_Click(object sender, EventArgs e)
        {
            AddPastHistory form = new AddPastHistory();
            form.Show();
        }

        private void btn_addFamHistValue_Click(object sender, EventArgs e)
        {
            AddFamilyHistory form = new AddFamilyHistory();
            form.Show();
        }

        private void btn_addMedicineLink_Click(object sender, EventArgs e)
        {
            AddNewMedicine form = new AddNewMedicine();
            form.Show();
        }

    }
}
