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
using Branch_project.Logic.Presenter;
using Branch_project.Views.InterFaces;
using System.Data.SqlClient;
using Branch_project.Models;
using Branch_project.Logic.Services;

namespace Branch_project.Views.Forms
{
    public partial class Frm_EditBranch : DevExpress.XtraEditors.XtraForm, IBranchCrud
    {

        BranchViewPresenter BranchViewPresenter;


        public string branchName_Txt { get => txt_branchName.Text; set => txt_branchName.Text=value; }
        public string branchEName_Txt { get => txt_branchEName.Text; set => txt_branchEName.Text=value; }
        public object currid_Txt { get => lkp_Currency.EditValue; set => lkp_Currency.EditValue = value; }
        public string manager_Txt { get => txt_manger.Text; set => txt_manger.Text = value; }
        public string emanager_Txt { get => txt_Emanager.Text; set => txt_Emanager.Text = value; }
        public string address_Txt { get => txt_address.Text; set => txt_address.Text = value; }
        public string eaddress_Txt { get => txt_Eaddress.Text; set => txt_Eaddress.Text = value; }
        public string tel1_Txt { get => txt_Phone1.Text; set => txt_Phone1.Text = value; }
        public string tel2_Txt { get => txt_phone2.Text; set => txt_phone2.Text = value; }
        public string fax_Txt { get => txt_fax.Text; set => txt_fax.Text = value; }
        public string email_Txt { get => txt_Email.Text; set => txt_Email.Text = value; }
        public string BranchID { get => _BranchID.ToString(); set => _BranchID = Convert.ToInt32( value); }
        public object GridDataSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int GridCounts => throw new NotImplementedException();

        // public object companyid_Txt { get => lkp_company.EditValue; set => lkp_company.EditValue = value; }


        public int _BranchID; 

        public Frm_EditBranch(int id)
        {
            _BranchID = id;
            InitializeComponent();
            BranchViewPresenter = new BranchViewPresenter(this);
        }

       
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            SqlConnection connection =  BranchViewPresenter.SQlConnection();
          var execute =  BranchViewPresenter.EditBranch(connection, BranchID, branchName_Txt, branchEName_Txt, Convert.ToInt32( currid_Txt.ToString()), manager_Txt, emanager_Txt, address_Txt, eaddress_Txt, tel1_Txt, tel2_Txt, fax_Txt, email_Txt, 1);

            if (execute == "Success")
            {
                MessageBox.Show("تمت تعديل  الفرع بنجاح");
            }
            else
            {
                MessageBox.Show(execute);
            }

        }

        private void Frm_AddBranch_Load(object sender, EventArgs e)
        {

           

            //Load Currency LookupEdit 

          BranchViewPresenter.  GetAllCurrency(lkp_Currency);

            var List = DbHelper.ExecuteSP<files_Branch>("spGetBranchs", null);

         var CurrentBranch =    List.SingleOrDefault(x=>x.branchid== Convert.ToInt32( BranchID));


            branchName_Txt = CurrentBranch.branchname;
         branchEName_Txt= CurrentBranch.branchename;
            currid_Txt = CurrentBranch.currid;
            manager_Txt  = CurrentBranch.manager;
            emanager_Txt  = CurrentBranch.emanager;
            address_Txt  = CurrentBranch.address;
            eaddress_Txt  = CurrentBranch.eaddress;
            tel1_Txt  = CurrentBranch.tel1;
            tel2_Txt = CurrentBranch.tel2;
            fax_Txt = CurrentBranch.fax;
            email_Txt = CurrentBranch.email;




        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            txt_address.Text = "";
            txt_branchEName.Text = "";
            txt_branchName.Text = "";
            txt_Eaddress.Text = "";
            txt_Email.Text = "";
            txt_Emanager.Text = "";
            txt_fax.Text = "";
            txt_manger.Text="";
            txt_Phone1.Text = "";
            txt_phone2.Text = "";
            lkp_Currency.Properties.NullText = "[اختر العملة]";

            
        }
    }
}