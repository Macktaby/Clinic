﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic.Froms
{
    public partial class TransferDetails : Form
    {

        public TransferDetails()
        {
            InitializeComponent();

            DateTime now = DateTime.Today;
            txt_currentDate.Text = now.ToString("dd/MM/yyyy");
        }

        public TransferDetails(string patientName, string patientAge)
            : this()
        {
            txt_patName.Text = patientName;
            txt_age.Text = patientAge;
        }

        private void btn_printAction_Click(object sender, EventArgs e)
        {
            using (TransferPrint frm = new TransferPrint(
                txt_patName.Text,
                txt_age.Text,
                txt_reason.Text,
                date_transfer.Value.ToString("dd/MM/yyyy"),
                txt_currentDate.Text,
                combo_fasting.Text + " " + combo_fastingPer.Text,
                combo_entry.Text + " " + combo_entryPer.Text
                ))
            {
                frm.ShowDialog();
            }
        }

    }
}
