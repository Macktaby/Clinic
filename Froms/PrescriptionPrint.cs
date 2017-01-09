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
        private List<string> meds;
        private List<string> doses;
        private List<string> images;

        public PrescriptionPrint()
        {
            InitializeComponent();
            this.reportViewer.LocalReport.EnableExternalImages = true;
        }

        public PrescriptionPrint(List<string> meds, List<string> doses, List<string> images)
            : this()
        {
            this.meds = meds;
            this.doses = doses;
            this.images = images;
        }

        private void PrescriptionPrint_Load(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[(meds.Count*2)+images.Count];

            for (int i = 0; i < meds.Count; i++)
            {
                para[2 * i] = new Microsoft.Reporting.WinForms.ReportParameter("med" + (i + 1), meds[i]);
                para[2 * i + 1] = new Microsoft.Reporting.WinForms.ReportParameter("dose" + (i + 1), doses[i]);
            }

            for (int i = 0; i < images.Count; i++)
            {
                para[(meds.Count * 2)+i] = new Microsoft.Reporting.WinForms.ReportParameter("image" + (i + 1), images[i]);
            }

            this.reportViewer.LocalReport.SetParameters(para);
            this.reportViewer.RefreshReport();
        }
    }
}
