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
    public partial class AddNewLab : Form
    {
        private OleDbConnection conn;
        private String connectionStr;

        private int patientID;

        public AddNewLab()
        {
            InitializeComponent();
            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);
        }

        public AddNewLab(int patientID)
            : this()
        {
            this.patientID = patientID;
        }

        private void btn_addLabAction_Click(object sender, EventArgs e)
        {
            addLab();
        }

        private int addLab()
        {
            try
            {
                conn.Open();

                String sql = "INSERT INTO Lab "
                    + "(lab_name, lab_result, patient_id) "
                    + "VALUES (@lName, @lResult, @pID)";

                OleDbCommand command = new OleDbCommand(sql, conn);

                command.Parameters.AddWithValue("@lName", combo_labName.Text);
                command.Parameters.AddWithValue("@lResult", txt_labResult.Text);
                command.Parameters.AddWithValue("@fID", patientID);

                command.ExecuteNonQuery();

                command = new OleDbCommand("SELECT @@IDENTITY", conn);
                int id = (int)command.ExecuteScalar();

                return id;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Occured !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                MessageBox.Show("Done");
                conn.Close();
            }
        }
    }
}
