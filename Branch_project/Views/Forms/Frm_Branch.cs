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
    }
}