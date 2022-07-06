using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.SqlClient;
using Branch_project.Logic.Services;
using Branch_project.Models;
using Branch_project.Views.Reports;

namespace Branch_project.Views.Forms
{
    public partial class Frm_Branch : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Branch()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_ShowBranches frm_ShowBranches = new Frm_ShowBranches();
            frm_ShowBranches.ShowDialog();
        }


        public SqlConnection ConnectSQl()
        {

            try
            {
                string connectionstring = @"data source=SERVER2012\SERVER_2005;initial catalog=EasyErp_newteam;user id=sa;password=walan1@3;";
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                return con;

                      }
            catch (Exception ex) { MessageBox.Show(ex.Message); return null; }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_AddBranch frm_AddBranch = new Frm_AddBranch();
            frm_AddBranch.ShowDialog();




        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            //Frm_Report frm_Report = new Frm_Report();
            //frm_Report.ShowDialog();

            //List<files_Branch> ListItem;

            //ListItem = DbHelper.ExecuteSP<files_Branch>("spGetBranchs", null);
            List<File_Branch_view> ListItem;

            ListItem = DbHelper.ExecuteSP<File_Branch_view>("spvm_Branch", null);


            XtraReport1.Print(ListItem);

        }

        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            XtraReport1 report1 = new XtraReport1();
            new frm_ReportDesigner(report1).ShowDialog();
        }
    }
}