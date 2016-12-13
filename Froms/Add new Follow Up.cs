﻿using System;
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
        int patientID = 0;

        public Add_new_Follow_Up()
        {
            InitializeComponent();
            connectionStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ClinicDB.accdb";
            conn = new OleDbConnection(connectionStr);
        }
        public Add_new_Follow_Up(int patientID)
            : this()
        {
            this.patientID = patientID;
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
            //addPastHistory(followUpID);
            //addFamilyHistoy(followUpID);
        }

        private void addFamilyHistoy(int followUpID)
        {
            throw new NotImplementedException();
        }

        private void addPastHistory(int followUpID)
        {
            throw new NotImplementedException();
        }

        private int addFollowUp()
        {
            try
            {
                conn.Open();

                String sql = "INSERT INTO Follow_Up "
                    + "(patient_id, parity_a, parity_b, living, male, female, lmp, rh, menarchal, cycle_d, cycle_c, notes) "
                    + "VALUES (@pID, @parA, @parB, @living, @male, @female, @lmp, @rh, @men, @cycleD, @cycleC, @notes)";

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

                command.ExecuteNonQuery();

                command = new OleDbCommand("SELECT @@IDENTITY", conn);

                int id = (int)command.ExecuteScalar();
                MessageBox.Show(id.ToString());
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
            if (string.IsNullOrEmpty(combo_familyHistory.SelectedText))
            {
                MessageBox.Show("RH is not selected");
                return "";
            }

            return combo_rh.SelectedItem.ToString();
        }

        private void btn_addFHistory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(combo_familyHistory.SelectedText))
            {
                MessageBox.Show("No value selected");
                return;
            }
            String fHistory = combo_familyHistory.SelectedItem.ToString();
            listBox_FamilyHistory.Items.Add(fHistory);
        }

        private void btn_addPHistory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(combo_pastHistory.SelectedText))
            {
                MessageBox.Show("No value selected");
                return;
            }

            String pHistory = combo_pastHistory.SelectedItem.ToString();
            listBox_pastHistory.Items.Add(pHistory);
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
                listBox_pastHistory.Items.RemoveAt(intselectedindex);
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
                listBox_FamilyHistory.Items.RemoveAt(intselectedindex);
        }
    }
}
