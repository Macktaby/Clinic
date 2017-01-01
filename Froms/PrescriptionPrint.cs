using System;
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
    public partial class PrescriptionPrint : Form
    {
        private string med;

        public PrescriptionPrint()
        {
            InitializeComponent();
            this.reportViewer.LocalReport.EnableExternalImages = true;
        }

        public PrescriptionPrint(string med)
            : this()
        {
            this.med = med;
        }

        private void PrescriptionPrint_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("med", med)
            };

            this.reportViewer.LocalReport.SetParameters(para);
            this.reportViewer.RefreshReport();
        }
    }
}
