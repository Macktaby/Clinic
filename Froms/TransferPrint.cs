using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting;

namespace Clinic.Froms
{

    public partial class TransferPrint : Form
    {
        private String name;
        private String age;
        private String reason;
        private String date;
        private String currDate;
        private string fas;
        private string entry;

        public TransferPrint(String name, String age, String reason, String date, String currDate, String fas, String entry)
        {
            InitializeComponent();

            this.name = name;
            this.age = age;
            this.reason = reason;
            this.date = date;
            this.currDate = currDate;
            this.fas = fas;
            this.entry = entry;
        }

        private void TransferPrint_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();

            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pName", name), 
                new Microsoft.Reporting.WinForms.ReportParameter("age", age), 
                new Microsoft.Reporting.WinForms.ReportParameter("date", date), 
                new Microsoft.Reporting.WinForms.ReportParameter("transfer", reason), 
                new Microsoft.Reporting.WinForms.ReportParameter("currentDate", currDate),
                new Microsoft.Reporting.WinForms.ReportParameter("fasting", fas), 
                new Microsoft.Reporting.WinForms.ReportParameter("hosEntry", entry)
            };

            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }
    }
}
