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
using Branch_project.Logic.Services;
using Branch_project.Models;
using System.Data.SqlClient;
using Branch_project.Logic.Presenter;
using Branch_project.Views.InterFaces;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace Branch_project.Views.Forms
{
    public partial class Frm_ShowBranches : DevExpress.XtraEditors.XtraForm, IBranchCrud
    {
        BranchViewPresenter BranchViewPresenter;

        public string BranchID { get => gridView1.GetRowCellValue(gridView1.GetFocusedDataSourceRowIndex(), "branchid").ToString(); set => throw new NotImplementedException(); }
        public string branchName_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string branchEName_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object currid_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string manager_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string emanager_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string address_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string eaddress_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string tel1_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string tel2_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string fax_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string email_Txt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object GridDataSource { get => gridControl1.DataSource; set => gridControl1.DataSource = value; }
        public int GridCounts { get => gridView1.RowCount; }

        public Frm_ShowBranches()
        {
            InitializeComponent(); 
            BranchViewPresenter = new BranchViewPresenter(this);
            BranchViewPresenter.RefreshData();
            gridView1.Columns["branchid"].Visible = false;
            barHeaderItem2.Caption = gridView1.RowCount.ToString();
        }


        #region Functions



        void AddRepoButtonToGridView()
        {

            RepositoryItemButtonEdit Edit = new RepositoryItemButtonEdit();

            RepositoryItemButtonEdit Delete = new RepositoryItemButtonEdit();




            gridView1.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn() { FieldName = "MyFieldName", Caption = "MyFieldName", ColumnEdit = Edit, ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways, VisibleIndex = 100 }) ;
            gridControl1.RepositoryItems.Add(Edit);
            gridControl1.RepositoryItems.Add(Delete);


            // gridView1.Columns["MyFieldName"].ColumnEdit = Edit;

            gridView1.OptionsBehavior.Editable = false;
            Edit.Buttons[0].Kind = ButtonPredefines.Search;
            //Edit.Buttons[1].Kind = ButtonPredefines.Delete;
            Edit.Click += Edit_Click; ;


        }

        private void Edit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }

     

        void GridControlSettings()
        {

            RepositoryItemLookUpEdit lkp = new RepositoryItemLookUpEdit();
            var ss = DbHelper.ExecuteSP<files_Curr>("spSelectCur", null);
            lkp.DataSource = ss;

            lkp.ValueMember = nameof(files_Curr.currid);
            lkp.DisplayMember = nameof(files_Curr.currname);

            gridControl1.RepositoryItems.Add(lkp);
            gridView1.Columns["currid"].ColumnEdit = lkp;

            gridView1.OptionsBehavior.Editable = false;
        }
        #endregion

        private void Frm_ShowBranches_Load(object sender, EventArgs e)
        {
            BranchViewPresenter.RefreshData();
            gridView1.Columns["branchid"].Visible = false;
            barHeaderItem2.Caption = gridView1.RowCount.ToString();




            GridControlSettings();
            AddRepoButtonToGridView();
        }

        private void barHeaderItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btn_AddBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_AddBranch Frm_AddBranch = new Frm_AddBranch();

            Frm_AddBranch.ShowDialog();
            BranchViewPresenter.RefreshData();
            gridView1.Columns["branchid"].Visible = false;
            barHeaderItem2.Caption = gridView1.RowCount.ToString();


        }
      

        private void btn_RemoveBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            

       

        SqlConnection Connection  =  BranchViewPresenter.SQlConnection();

            var Execute = BranchViewPresenter.DeleteBranch(Connection);
            if (Execute == "Success")
            {
                MessageBox.Show("تم حذف الفرع بنجاح");
            }
            else { MessageBox.Show(Execute); }


            BranchViewPresenter.RefreshData();
            gridView1.Columns["branchid"].Visible = false;
            barHeaderItem2.Caption = gridView1.RowCount.ToString();


        }

        private void btn_EditBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frm_EditBranch Frm_EditBranch = new Frm_EditBranch(Convert.ToInt32( BranchID));

            Frm_EditBranch.ShowDialog();
            BranchViewPresenter.RefreshData();
            gridView1.Columns["branchid"].Visible = false;
            barHeaderItem2.Caption = gridView1.RowCount.ToString();
        }
    }
}