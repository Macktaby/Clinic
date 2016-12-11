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

namespace Clinic
{
    public partial class Select_Patient : Form
    {
        private OleDbDataReader dr;

        public Select_Patient()
        {
            InitializeComponent();
        }

        public Select_Patient(OleDbDataReader dr)
        {
            InitializeComponent();
            this.dr = dr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Select_Patient_Load(object sender, EventArgs e)
        {
            while (dr.Read())
            {
                ListViewItem lvi = new ListViewItem(dr["patient_id"].ToString());
                lvi.SubItems.Add(dr["patient_name"].ToString());
                lvi.SubItems.Add(dr["phone"].ToString());
                listView.Items.Add(lvi);
            }

        }
    }
}
