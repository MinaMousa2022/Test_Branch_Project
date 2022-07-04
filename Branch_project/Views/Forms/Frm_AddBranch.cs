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
using DevExpress.XtraEditors;

namespace Branch_project.Views.Forms
{
    public partial class Frm_AddBranch : DevExpress.XtraEditors.XtraForm, IBranchCrud
    {

        BranchViewPresenter BranchViewPresenter;


        public string branchName_Txt { get =>  txt_branchName.Text; set => txt_branchName.Text=value; }
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
        public string BranchID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object GridDataSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GridCounts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // public object companyid_Txt { get => lkp_company.EditValue; set => lkp_company.EditValue = value; }



        public Frm_AddBranch()
        {
            InitializeComponent();
            BranchViewPresenter = new BranchViewPresenter(this);
            
        }


        bool ControlsValidation(TextEdit TextEdit)
        {

            if (TextEdit.Text == String.Empty)
            {

                TextEdit.ErrorText = "يرجي ادخال هذا الحقل";

                return false;
            }
            return true;
        
        
        
        
        }


        bool ControlsValidation(LookUpEdit lkp)
        {

            if (lkp.Text == String.Empty)
            {

                lkp.ErrorText = "يرجي اختيار العملة";

                return false;
            }
            return true;




        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

            int CheckException = 0;

            CheckException += (ControlsValidation(txt_branchName)) ? 0 : 1;
            CheckException += (ControlsValidation(txt_manger)) ? 0 : 1;
            CheckException += (ControlsValidation(txt_Emanager)) ? 0 : 1;
            CheckException += (ControlsValidation(txt_address)) ? 0 : 1;
            CheckException += (ControlsValidation(lkp_Currency)) ? 0 : 1;
            CheckException += (ControlsValidation(txt_Eaddress)) ? 0 : 1;
            CheckException += (ControlsValidation(txt_Phone1)) ? 0 : 1;
            CheckException += (ControlsValidation(txt_phone2)) ? 0 : 1;
            CheckException += (ControlsValidation(txt_fax)) ? 0 : 1;
            CheckException += (ControlsValidation(txt_Email)) ? 0 : 1;

            if (CheckException > 0) return;



            SqlConnection connection =  BranchViewPresenter.SQlConnection();



          var execute =  BranchViewPresenter.AddBranch(connection, branchName_Txt, branchEName_Txt, Convert.ToInt32( currid_Txt.ToString()), manager_Txt, emanager_Txt, address_Txt, eaddress_Txt, tel1_Txt, tel2_Txt, fax_Txt, email_Txt, 1);

            if (execute == "Success")
            {
                MessageBox.Show("تمت اضافة الفرع بنجاح");
            }
            else
            {
                MessageBox.Show(execute);
            }

        }

        private void Frm_AddBranch_Load(object sender, EventArgs e)
        {

           


          BranchViewPresenter.  GetAllCurrency(lkp_Currency);

          



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