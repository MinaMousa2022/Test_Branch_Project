using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Branch_project.Models;
using DevExpress.XtraPrinting.Preview;
using System.IO;

namespace Branch_project.Views.Reports
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
            try
            {
                this.LoadLayout("XtraReport1");
            }
            catch (Exception)
            {

            }
            
            txt_Address.ExpressionBindings.Add(new ExpressionBinding("BeforePrint","Text",nameof(files_Branch.address)));
            txt_EAddress.ExpressionBindings.Add(new ExpressionBinding("BeforePrint","Text", nameof(files_Branch.eaddress)));
            txt_branchEname.ExpressionBindings.Add(new ExpressionBinding("BeforePrint","Text", nameof(files_Branch.branchename)));
            txt_BranchName.ExpressionBindings.Add(new ExpressionBinding("BeforePrint","Text", nameof(files_Branch.branchname)));
            txt_Curr.ExpressionBindings.Add(new ExpressionBinding("BeforePrint","Text", nameof(File_Branch_view.currname)));
            //txt_company.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", nameof(files_Branch.companyid)));
            //txt_Curr.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", nameof(files_Branch.currid)));
            //txt_EManeger.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", nameof(files_Branch.manager)));
            //txt_Curr.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", nameof(files_Branch.currid)));
            //txt_Curr.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", nameof(files_Branch.currid)));
        }
        public static void Print(object DataSource )
        {
            XtraReport1 report = new XtraReport1();
            report.DataSource = DataSource;
            //document.DocumentSource = report;
            //document.Show();
            report.ShowPreview();

        }

    }
}
