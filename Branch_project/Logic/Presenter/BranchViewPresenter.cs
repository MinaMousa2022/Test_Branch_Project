using Branch_project.Logic.Services;
using Branch_project.Models;
using Branch_project.Views.InterFaces;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Branch_project.Logic.Presenter
{
    class BranchViewPresenter
    {




        #region Fields

        private readonly IBranchCrud BranchRepo;



        #endregion



        #region Constractors

        public BranchViewPresenter(IBranchCrud reop)
        {
            BranchRepo = reop;

            // RefreshData();


        }

        #endregion



        #region Functions

        public SqlConnection SQlConnection()
        {

            try
            {
                string connectionstring = @"data source=SERVER2012\SERVER_2005;initial catalog=EasyErp_newteam;user id=sa;password=walan1@3;";
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                return con;

            }
            catch (Exception ex) { /*MessageBox.Show(ex.Message);*/ return null; }
        }
        public string AddBranch(SqlConnection Connection, string branchname, string branchename, int currid, string manager, string emanager, string address, string eaddress, string tel1, string tel2, string fax, string email, int companyId)
        {
            string ReturnString = "";

            try
            {

                SqlCommand sqlCmd = new SqlCommand("spAddBranch", Connection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@branchname", SqlDbType.NVarChar).Value = branchname;
                sqlCmd.Parameters.AddWithValue("@branchename", SqlDbType.NVarChar).Value = branchename;
                sqlCmd.Parameters.AddWithValue("@currid", SqlDbType.Int).Value = currid;
                sqlCmd.Parameters.AddWithValue("@manager", SqlDbType.NVarChar).Value = manager;
                sqlCmd.Parameters.AddWithValue("@emanager", SqlDbType.NVarChar).Value = emanager;
                sqlCmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = address;

                sqlCmd.Parameters.AddWithValue("@eaddress", SqlDbType.NVarChar).Value = eaddress;
                sqlCmd.Parameters.AddWithValue("@tel1", SqlDbType.NVarChar).Value = tel1;



                sqlCmd.Parameters.AddWithValue("@tel2", SqlDbType.NVarChar).Value = tel2;


                sqlCmd.Parameters.AddWithValue("@fax", SqlDbType.NVarChar).Value = fax;

                sqlCmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = email;
                sqlCmd.Parameters.AddWithValue("@companyid", SqlDbType.Int).Value = companyId;

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                ReturnString = "Success";


                return ReturnString;
            }
            catch (Exception ex)
            {

                ReturnString = ex.Message;
                return ReturnString;
            }

        }
        public string EditBranch(SqlConnection Connection,string branchID, string branchname, string branchename, int currid, string manager, string emanager, string address, string eaddress, string tel1, string tel2, string fax, string email, int companyId)
        {
            string ReturnString = "";

            try
            {

                SqlCommand sqlCmd = new SqlCommand("spUpdateBranch", Connection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@branchid", SqlDbType.NVarChar).Value = branchID;
                sqlCmd.Parameters.AddWithValue("@branchname", SqlDbType.NVarChar).Value = branchname;
                sqlCmd.Parameters.AddWithValue("@branchename", SqlDbType.NVarChar).Value = branchename;
                sqlCmd.Parameters.AddWithValue("@currid", SqlDbType.Int).Value = currid;
                sqlCmd.Parameters.AddWithValue("@manager", SqlDbType.NVarChar).Value = manager;
                sqlCmd.Parameters.AddWithValue("@emanager", SqlDbType.NVarChar).Value = emanager;
                sqlCmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = address;

                sqlCmd.Parameters.AddWithValue("@eaddress", SqlDbType.NVarChar).Value = eaddress;
                sqlCmd.Parameters.AddWithValue("@tel1", SqlDbType.NVarChar).Value = tel1;



                sqlCmd.Parameters.AddWithValue("@tel2", SqlDbType.NVarChar).Value = tel2;


                sqlCmd.Parameters.AddWithValue("@fax", SqlDbType.NVarChar).Value = fax;

                sqlCmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = email;
                sqlCmd.Parameters.AddWithValue("@companyid", SqlDbType.Int).Value = companyId;

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                ReturnString = "Success";


                return ReturnString;
            }
            catch (Exception ex)
            {

                ReturnString = ex.Message;
                return ReturnString;
            }

        }

        public string DeleteBranch(SqlConnection Connection)
        {

            try { 

            SqlCommand sqlCmd = new SqlCommand("spDeleteBranch", Connection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", SqlDbType.NVarChar).Value = BranchRepo.BranchID;
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();

                return "Success";
            }
            catch (Exception ex) { return ex.Message; }

        }
        public void RefreshData()
        {

            var List = DbHelper.ExecuteSP<files_Branch>("spGetBranchs", null);
            BranchRepo.GridDataSource = List;
            // gridView1.Columns["files_Curr"].Visible = false;
        }
        public List<files_Curr> GetAllCurrency(LookUpEdit lkp_Currency)
        {


            var ListOFCurrency = DbHelper.ExecuteSP<files_Curr>("spSelectCur", null);


            return ListOFCurrency;
        }

        #endregion





    }
}
