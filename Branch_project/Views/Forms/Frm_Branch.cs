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
            //List<SqlParameter> Params = new List<SqlParameter>();
            //SqlParameter sqlParameter1 = new SqlParameter();
            //sqlParameter1.Value = "";
            //sqlParameter1.ParameterName = "";
            //sqlParameter1.SqlDbType = SqlDbType.NVarChar;
            //Params.Add(sqlParameter1);
            //DbHelper.ExecuteSP("spAddBranch",Params);
            try
            {
                SqlCommand sqlCmd = new SqlCommand("spAddBranch", ConnectSQl());
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@branchname", SqlDbType.NVarChar).Value = "اسم عربي";
                sqlCmd.Parameters.AddWithValue("@branchename", SqlDbType.NVarChar).Value = "English Name";
                sqlCmd.Parameters.AddWithValue("@currid", SqlDbType.Int).Value = 1;
                sqlCmd.Parameters.AddWithValue("@manager", SqlDbType.NVarChar).Value = "المدير";
                sqlCmd.Parameters.AddWithValue("@emanager", SqlDbType.NVarChar).Value = "ENg Manager";
                sqlCmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = "العنوان";

                sqlCmd.Parameters.AddWithValue("@eaddress", SqlDbType.NVarChar).Value = "English Address";
                sqlCmd.Parameters.AddWithValue("@tel1", SqlDbType.NVarChar).Value = "11111111111";



                sqlCmd.Parameters.AddWithValue("@tel2", SqlDbType.NVarChar).Value = "222222222";


                sqlCmd.Parameters.AddWithValue("@fax", SqlDbType.NVarChar).Value = "4444444";

                sqlCmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = "test@gmail.com";
                sqlCmd.Parameters.AddWithValue("@companyid", SqlDbType.Int).Value = 11;

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}