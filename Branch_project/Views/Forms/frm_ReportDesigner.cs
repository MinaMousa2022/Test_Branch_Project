using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Branch_project.Views.Forms
{
    public partial class frm_ReportDesigner : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraReports.UI.XtraReport report;
        public frm_ReportDesigner(DevExpress.XtraReports.UI.XtraReport Report )
        {
            InitializeComponent();
            report = Report;
            reportDesigner1.OpenReport(report);
        }

        private void bbiSaveFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            report.SaveLayout("XtraReport1");
        }
    }
}